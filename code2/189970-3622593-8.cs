    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text;
    
    namespace XMLTest
    {
        public struct Segment
        {
            public Segment(long index, long length)
            {
                Index = index;
                Length = length;
            }
    
            public long Index;
            public long Length;
    
            public override string ToString()
            {
                return string.Format("Segment({0}, {1})", Index, Length);
            }
        }
    
        public static class GeneralSerializationExtensions
        {
            public static string Segment(this string buffer, Segment segment)
            {
                return buffer.Substring((int)segment.Index, (int)segment.Length);
            }
    
            public static byte[] Bytes(this Stream stream, int startIndex = 0, bool setBack = false)
            {
                var bytes = new byte[stream.Length];
                if (stream.CanSeek && stream.CanRead)
                {
                    var position = stream.Position;
                    stream.Seek(startIndex, SeekOrigin.Begin);
                    stream.Read(bytes, 0, (int)stream.Length);
                    if (setBack)
                        stream.Position = position;
                }
                return bytes;
            }        
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var stream = new MemoryStream();
                var element = XElement.Parse(@"<root><group id=""0"" combiner=""or""><filter id=""1"" /><filter id=""2"" /></group></root>");            
                //var element = XElement.Parse("<a>i<b id='1' o='2' p=''/><b id='2'><c /></b><b id='3' /><b id='4' o='u'>2</b></a>");
    
                var pie = new PathIndexedXElement(element);
    
                foreach (var path in pie.Paths.OrderBy(p => p))
                {
                    var s = pie.store[path];
                    var t = pie[path];
                    Console.WriteLine("> {2,-30} {0,-20} {1}", s, t, path);
                }
            }
        }
    
        public class PathIndexedXElement
        {
            internal string buffer;
            internal ConcurrentDictionary<string, Segment> store;
    
            public PathIndexedXElement(XElement element)
            {
                buffer = XmlPathSegmenter.StringBuffer(element);
                store = element.PathSegments();
            }
    
            public IEnumerable<string> Paths
            {
                get { return store.Keys; }
            }
    
            public string this[string path]
            {
                get { return buffer.Segment(store[path]); }
            }
    
            public bool TryGetValue(string path, out string xelement)
            {
                Segment segment;
                if (store.TryGetValue(path, out segment))
                {
                    xelement = buffer.Segment(segment);
                    return true;
                }
                xelement = null;
                return false;
            }
        }
    
        public static class XmlPathSegmenter
        {
            public static XmlWriter CreateWriter(Stream stream)
            {
                var settings = new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = false, OmitXmlDeclaration = true, NewLineHandling = NewLineHandling.None };
                
                return XmlWriter.Create(stream, settings);
            }
    
            public static MemoryStream MemoryBuffer(XElement element)
            {
                var stream = new MemoryStream();
                var writer = CreateWriter(stream);
                element.Save(writer);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
    
            public static string StringBuffer(XElement element)
            {
                return Encoding.UTF8.GetString(MemoryBuffer(element).Bytes()).Substring(1);
            }
    
            public static ConcurrentDictionary<string, Segment> PathSegments(string xmlElement, ConcurrentDictionary<string, Segment> store = null)
            {
                return PathSegments(XElement.Parse(xmlElement), store);
            }
    
            public static ConcurrentDictionary<string, Segment> PathSegments(this XElement element, ConcurrentDictionary<string, Segment> store = null)
            {
                var stream = new MemoryStream();
                var writer = CreateWriter(stream);
                element.Save(writer);
                writer.Flush();
                stream.Position = 0;
    
                return PathSegments(stream, store);
            }
    
            public static ConcurrentDictionary<string, Segment> PathSegments(Stream stream, ConcurrentDictionary<string, Segment> store = null)
            {
                if (store == null)
                    store = new ConcurrentDictionary<string, Segment>();
                
                var stack = new ConcurrentStack<KeyValuePair<string, int>>();
                PathSegments(stream, stack, store);
                
                return store;
            }
    
            //
            static void PathSegments(Stream stream, ConcurrentStack<KeyValuePair<string, int>> stack, ConcurrentDictionary<string, Segment> store)
            {
                var reader = XmlReader.Create(stream, new XmlReaderSettings() { });
                var line = reader as IXmlLineInfo;
    
                while (reader.Read())
                {
                    KeyValuePair<string, int> ep;
                ok:
                    if (reader.IsStartElement())
                    {
                        stack.TryPeek(out ep);
                        stack.Push(new KeyValuePair<string, int>(ep.Key + Path(reader), line.LinePosition - 2));
                    }
    
                    if (reader.IsEmptyElement)
                    {
                        var name = reader.LocalName;
                        var d = reader.Depth;
                        reader.Read();
                        if (stack.TryPop(out ep))
                        {
                            var length = line.LinePosition - 2 - ep.Value - (d > reader.Depth ? 1 : 0);
                            Console.WriteLine("/{3}|{0} : {1} -> {2}", name, ep.Value, length, line.LineNumber);
    
                            store.TryAdd(ep.Key, new Segment(ep.Value, length));
                        }
                        goto ok;
                    }
    
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (stack.TryPop(out ep))
                        {
                            var length = line.LinePosition + reader.LocalName.Length - ep.Value;
                            Console.WriteLine("|{3}|{0} : {1} -> {2}", reader.LocalName, ep.Value, length, line.LineNumber);
    
                            store.TryAdd(ep.Key, new Segment(ep.Value, length));
                        }
                    }
    
                }
            }
            //
    
            public static string Path(XmlReader element)
            {
                if (!(element.IsStartElement() || element.IsEmptyElement))
                    return null;
    
                if (!element.HasAttributes)
                    return "/" + element.LocalName;
                var id = element.GetAttribute("id");
                return string.Format(id == null ? "/{0}" : "/{0}-{1}", element.LocalName, id);
            }
        }
    }

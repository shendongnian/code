cs
var handler = new VDS.RDF.Parsing.Handlers.CountHandler();
CellLineOntology.RdfXmlParser.Load(handler, @"..\..\..\..\clo.owl");
I get a count of 1,387,097 statements using the file you linked.
---
cs
namespace CellLineOntology
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using VDS.RDF;
    using VDS.RDF.Parsing.Contexts;
    using VDS.RDF.Parsing.Events;
    using VDS.RDF.Parsing.Events.RdfXml;
    using VDS.RDF.Parsing.Handlers;
    internal class RdfXmlParser
    {
        public static void Load(IRdfHandler handler, string filename)
        {
            using (var input = File.OpenRead(filename))
            {
                Parse(new Context(handler, input));
            }
        }
        private static void Parse(RdfXmlParserContext context) => typeof(VDS.RDF.Parsing.RdfXmlParser).GetMethod("Parse", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(new VDS.RDF.Parsing.RdfXmlParser(), new[] { context });
        private class Context : RdfXmlParserContext
        {
            private IEventQueue<IRdfXmlEvent> _queue
            {
                set => typeof(RdfXmlParserContext).GetField("_queue", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, value);
            }
            public Context(IRdfHandler handler, Stream input)
                : base(handler, Stream.Null)
            {
                _queue = new StreamingEventQueue<IRdfXmlEvent>(new Generator(input, ToSafeString(GetBaseUri(handler))));
            }
            private static Uri GetBaseUri(IRdfHandler handler) => (Uri)typeof(HandlerExtensions).GetMethod("GetBaseUri", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new[] { handler });
            private static string ToSafeString(Uri uri) => (uri == null) ? string.Empty : uri.AbsoluteUri;
            private class Generator : StreamingEventGenerator
            {
                private XmlReader _reader
                {
                    set => typeof(StreamingEventGenerator).GetField("_reader", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, value);
                }
                private bool _hasLineInfo
                {
                    set => typeof(StreamingEventGenerator).GetField("_hasLineInfo", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, value);
                }
                private string _currentBaseUri
                {
                    set => typeof(StreamingEventGenerator).GetField("_currentBaseUri", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, value);
                }
                public Generator(Stream stream)
                    : base(Stream.Null)
                {
                    var settings = GetSettings();
                    // This is why we're here
                    settings.MaxCharactersFromEntities = 0;
                    var reader = XmlReader.Create(stream, settings);
                    _reader = reader;
                    _hasLineInfo = reader is IXmlLineInfo;
                }
                public Generator(Stream stream, string baseUri)
                    : this(stream)
                {
                    _currentBaseUri = baseUri;
                }
                private XmlReaderSettings GetSettings() => (XmlReaderSettings)typeof(StreamingEventGenerator).GetMethod("GetSettings", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, null);
            }
        }
    }
}

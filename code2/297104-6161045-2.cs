	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml;
	
	namespace ConsoleApplication4 
	{
	    public class XPathGrepper : IDisposable
	    {
	        private XmlReader _rdr;
	        private TextWriter _out;
	
	        public XPathGrepper(string xmlFilepath, TextWriter output) {
	            _rdr = CreateXmlReader(xmlFilepath);
	            _out = output;
	        }
	
	        private static XmlReader CreateXmlReader(string xmlFilepath) {
	            XmlReaderSettings settings = new XmlReaderSettings();
	            settings.IgnoreWhitespace = true;
	            settings.IgnoreComments = true;
	            return XmlReader.Create(xmlFilepath, settings);
	        }
	
	        // descends through the XML, printing the xpath to each @attributeName.
	        public void Attributes(string attributeName) {
	            Attributes(_rdr, attributeName, "/");
	        }
	        // a recursive XML-tree descent, printing the xpath to each @attributeName.
	        private void Attributes(XmlReader rdr, string attrName, string path) {
	            // skip the containing element of the subtree (except root)
	            if ( "/" != path ) 
	                rdr.Read();
	            // count how many times we've seen each distinct path.
	            var kids = new Histogram();
	            // foreach node at-this-level in the tree
	            while ( rdr.Read() ) {
	                if (rdr.NodeType == XmlNodeType.Element) {
	                    // build the xpath-string to this element
	                    string nodePath = path + _rdr.LocalName;
	                    nodePath += "[" + kids.Increment(nodePath) + "]/";
	                    // print the xpath to the Caption attribute of this node
	                    if ( _rdr.HasAttributes && _rdr.GetAttribute(attrName) != null ) {
	                        _out.WriteLine(nodePath + "@" + attrName);
	                    }
	                    // recursively read the subtree of this element.
	                    Attributes(rdr.ReadSubtree(), attrName, nodePath);
	                }
	            }
	        }
	
	        public void Dispose() {
	            if ( _rdr != null ) _rdr.Close();
	        }
	
	        private static void Pause() {
	            Console.Write("Press enter to continue....");
	            Console.ReadLine();
	        }
	
	        static void Main(string[] args) {
	            using ( var grep = new XPathGrepper("Test.xml", Console.Out) ) {
	                grep.Attributes("Caption");
	            }
	            Pause();
	        }
	
	        private class Histogram : Dictionary<string, int>
	        {
	            public int Increment(string key) {
	                if ( base.ContainsKey(key) )
	                    base[key] += 1;
	                else
	                    base.Add(key, 1);
	                return base[key];
	            }
	        }
	
	    }
	}

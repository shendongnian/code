    using System;
    using System.IO;
    using System.Xml;
    
    
    class SOTest {
    
    	static void Main(string[] args) {
    		ParseXML(args[0]);
    	}
    
    	static void ParseXML(String path)
    	{
    		XmlReader reader = XmlReader.Create( new FileStream( path, FileMode.Open ) );
    
    		reader.Read();
    
    		while( reader.Read() )
    		{
    			// Only detect start elements.
    			if ( reader.IsStartElement() && reader.LocalName == "featureMember" && reader.NamespaceURI == "gml-namespace-uri" )
    			{
    				Console.WriteLine(reader.Name);
    				reader.ReadToDescendant("X", "ogr-namespace-uri");
    				Console.WriteLine(reader.ReadInnerXml());
    			}
    		}
    	}
    }

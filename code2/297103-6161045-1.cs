	using System;
	using System.Xml;
	
	namespace ConsoleApplication4 {
	    class Program {
	        static void Main(string[] args) {
	            // XML settings
	            XmlReaderSettings settings = new XmlReaderSettings();
	            settings.IgnoreWhitespace = true;
	            settings.IgnoreComments = true;
	
	            // Loop through the XML to get all text from the right attributes
	            using ( XmlReader reader = XmlReader.Create("Test.xml", settings) ) {
	                while ( reader.Read() ) {
	                    if ( reader.NodeType == XmlNodeType.Element ) {
	                        Console.Write(reader.LocalName + "/"); // <<<<----
	                        if ( reader.HasAttributes ) {
	                            if ( reader.GetAttribute("Caption") != null ) {
	                                Console.WriteLine(reader.GetAttribute("Caption"));
	                            }
	                        }
	                    }
	                }
	            }
	            Console.Write("Press any key ..."); Console.ReadKey();
	        }
	    }
	}

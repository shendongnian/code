    using System;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			XmlDocument xmlDocument = new XmlDocument();
    			xmlDocument.Load("XMLFile1.xml");
    			XmlNamespaceManager xmlnm = new XmlNamespaceManager(xmlDocument.NameTable);
    			xmlnm.AddNamespace("ns", "http://www.w3.org/2005/Atom");
    
    			ParseXML(xmlDocument, xmlnm);
    
    			Console.WriteLine("\n---XML parsed---");
    			Console.ReadKey();
    		}
    
    		public static void ParseXML(XmlDocument xmlFile, XmlNamespaceManager xmlnm)
    		{
    			XmlNodeList nodes = xmlFile.SelectNodes("//ns:updated | //ns:expires | //ns:title | //ns:summary | //ns:state", xmlnm);
    
    			foreach (XmlNode node in nodes)
    			{
    				Console.WriteLine(node.Name + " = " + node.InnerXml);
    			}
    		}
    	}
    }

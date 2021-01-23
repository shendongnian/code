    using System;
    using System.Xml;
    
    public class XPathNamespace
    {
    	public static void Main() {
    
    		XmlDocument doc = new XmlDocument();
    		doc.Load("test1.xml");
    
    		XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);
    		xnm.AddNamespace("p", "http://products.org");
    		xnm.AddNamespace("c", "http://camera.org");
    		xnm.AddNamespace("t", "http://tv.org");
    
    		ShowNode(doc.SelectSingleNode("/p:product", xnm));
    		ShowNode(doc.SelectSingleNode("/p:product/c:make", xnm));
    		ShowNode(doc.SelectSingleNode("/p:product/t:make", xnm));
    	}
    
    	private static void ShowNode(XmlNode node) {
    		Console.WriteLine("<{0}> {1}",
    						  node.LocalName, 
    						  node.NamespaceURI);
    	}
    }

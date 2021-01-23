    using System;
    using System.Xml;
    using System.Xml.XPath;
    
    public class XPathTest
    {
    	public static void Main() {
    
    		XmlDocument doc = new XmlDocument();
    		string xmlnodestr = @"<mynode value1='1' value2='123'>abc</mynode>
    <mynode value1='1' value2='123'>abc</mynode>
    <mynode value1='1' value2='123'>abc</mynode>";
    
    		XmlDocumentFragment frag = doc.CreateDocumentFragment();
    		frag.InnerXml = xmlnodestr;
    
    		XmlNodeList nodes = frag.SelectNodes("*");
    
    		foreach (XmlNode node in nodes)
    		{
    			Console.WriteLine(node.Name + " value1 = {0}; value2 = {1}",
    							  node.Attributes["value1"].Value,
    							  node.Attributes["value2"].Value);
    		}
    	}
    }

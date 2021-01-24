    using System;
    using System.Xml.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		// Create an XML tree in a namespace, with a specified prefix  
    		XNamespace ns = "http://example.com";
    		XElement root = new XElement("Root", 
    									 new XAttribute(XNamespace.Xmlns + "VATCore", "http://example.com"), 
    									 new XElement(ns + "Child", "child content")
    									);
    		Console.WriteLine(root);
    	}
    }

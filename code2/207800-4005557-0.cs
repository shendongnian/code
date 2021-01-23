    using System;
    using System.Xml;
    
    class Test {
    	static void Main ()
    	{
    		string s = "<Example> <Option1>x</Option1> <Option2>y</Option2> <Option3>z</Option3></Example>";
    		XmlDocument doc = new XmlDocument (); 
    		doc.LoadXml (s);
    		XmlNode n = doc.SelectSingleNode ("Example/Option1");
    		Console.WriteLine (n.InnerText);
    	}
    }

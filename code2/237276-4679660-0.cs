    public class Test
    {
    	public static int Main(string[] args)
    	{
    		const string xmlTxt = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <entry>
        <entry_id></entry_id>
        <entry_status></entry_status>
      </entry>";
    		TextReader treader = new StringReader(xmlTxt);
    		XmlReader xreader = XmlReader.Create(treader);
    		XmlDocument xdoc = new XmlDocument();
    		xdoc.Load(xreader);
    
    		XmlNode xnode = xdoc.SelectSingleNode("entry/entry_status");
    		//xnode.InnerText = "<![CDATA[something]]>";
    		xnode.InnerXml = "<![CDATA[something]]>";
    		Console.WriteLine("inner text is: " + xnode.InnerText);
    
    		xdoc.Save(Console.Out); Console.WriteLine();
    
    		return 0;
    	}
    }

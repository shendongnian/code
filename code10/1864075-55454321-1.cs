    using System;
    using System.Xml;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var badXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <Data>
      <Items>
        <Item>
          <Target type=""System.String"">Some target</Target>
          <Content type=""System.String""><?xml version=""1.0"" encoding=""utf-8""?><Data><Items><Item><surname type=""System.String"">Some Surname</surname><name type=""System.String"">Some Name</name></Item></Items></Data></Content>
        </Item>
      </Items>
    </Data>";
    		
    		var goodXML = badXML.Replace(@"<Content type=""System.String""><?xml version=""1.0"" encoding=""utf-8""?>"
    			                       , @"<Content type=""System.String"">");
    		
    		var xmlDoc = new XmlDocument();
    		xmlDoc.LoadXml(goodXML);
    		
    		XmlNodeList itemRefList = xmlDoc.GetElementsByTagName("Content");
    		foreach (XmlNode xn in itemRefList)
    		{
    			Console.WriteLine(xn.InnerXml);
    		}
    	}
    }

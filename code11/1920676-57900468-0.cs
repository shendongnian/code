cs
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
public class Program
{
	public static void Main()
	{
		var xmlString = @"<?xml version=""1.0""?>
<MainClass xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Items>
    <Settings xsi:type=""FileModel"">
      <Name>Rep1</Name>
      <IsActive>true</IsActive>
      <IsHidden>false</IsHidden>
    </Settings>
    <Settings xsi:type=""FileModel"">
      <Name>Rep2</Name>
      <IsActive>true</IsActive>
      <IsHidden>false</IsHidden>
    </Settings> 
   <Settings xsi:type=""ServerModel"">
      <Name>DelRep</Name>
      <IsActive>false</IsActive>
      <IsHidden>false</IsHidden>
    </Settings>
  </Items>
</MainClass>";
		
		var doc = XDocument.Parse(xmlString);
		var namespaceManager = new XmlNamespaceManager(new NameTable());
		namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
		var elements = doc.XPathSelectElements("/MainClass/Items/Settings[@xsi:type='FileModel']", namespaceManager);
		
		Console.WriteLine(elements.Count());
	}
}

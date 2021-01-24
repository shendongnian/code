if(xmlReader.NodeType == XmlNodeType.Text)
{
   string val = xmlReader.Value;
   Console.WriteLine(val);
}
For XmlNodeType.Element you can print out element name:
if(xmlReader.NodeType == XmlNodeType.Element)
{
   string val = xmlReader.Name;
   Console.WriteLine(val);
}

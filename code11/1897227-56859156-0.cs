C#
[Serializable]
[XmlRoot(ElementName="root")]
public class root
{
	[System.Xml.Serialization.XmlElementAttribute("group")]
	public List<Group> group { get; set; }
}
[Serializable()]
public class Group
{
	[System.Xml.Serialization.XmlAttributeAttribute("id")]
	public string id { get; set; }
	public Info info1 { get; set; }
	public Info info2 { get; set; }
}
[Serializable()]
public class Info
{
	[XmlElement]
	public string detail1 { get; set; }
	[XmlElement]
	public string detail2 { get; set; }
}
and examlpes:
C#
string xml = "<root><group id=\"one\"><info1><detail1>detail</detail1><detail2>detail</detail2></info1><info2><detail1>detail</detail1><detail2>detail</detail2></info2></group><group id=\"two\"><info1><detail1>detail</detail1><detail2>detail</detail2></info1><info2><detail1>detail</detail1><detail2>detail</detail2></info2></group></root>";
	XDocument x = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
	//option1
	XmlReader reader = x.CreateReader();
	DataSet ds = new DataSet();
	//DataSet will contain multiple tables
	ds.ReadXml(reader);
	
	//option 2
	XmlSerializer ser = new XmlSerializer(typeof(root));
	XmlReader reader2 = x.CreateReader();
	var res = ser.Deserialize(reader2);
as result you should have in option 1 DataSet with multiple tables, in option 2: loaded cobject "root":
[![result image][1]][1]
  [1]: https://i.stack.imgur.com/nZtUo.png

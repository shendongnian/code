C#
public partial class root
{
	public Table table {get;set;}
}
public partial class Table
{
	public Fields fields {get;set;}
}
public partial class Fields
{
	public Field field {get;set;}
}
public partial class Field
{
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string name {get;set;}
	[System.Xml.Serialization.XmlTextAttribute()]
	public string Value {get;set;}
}
and code (there are different approaches) i made up as example:
C#
string xml = "<root><table><fields><field name=\"createdBy\">Thomas</field></fields></table></root>";
	XDocument x = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
	XmlSerializer ser = new XmlSerializer(typeof(root));
	XmlReader reader2 = x.CreateReader();
	root res = (root)ser.Deserialize(reader2);
	var author = res.table.fields.field;
	Console.WriteLine($"{author.name} : {author.Value}");

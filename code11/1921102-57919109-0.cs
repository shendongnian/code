 c#
public class XmlInt32
{
    [XmlElement("int")]
    public int Value {get;set;}
    // not shown... maybe some implicit operators?
}
public class XmlString
{
    [XmlElement("string")]
    public string Value {get;set;}
    // not shown... maybe some implicit operators?
}
public class Model
{
    [XmlElement("ElementName")]
    public XmlString Name { get; set; }
    public XmlInt32 Number { get; set; }
}
Note, however, that this layout looks pretty unusual and atypical; frankly, I would *expect* the version in the top example in the question, not the bottom one. If you want to formally define the types of each element, that's usually done in a schema (xsd), not in the payload (xml).

 c#
[XmlRoot("RECEIPT")]
public class Receipt {
    [XmlElement("LINES")]
    public int LineCount {get;set;}
    [XmlElement("LINE")]
    public List<string> Lines {get;} = new List<string>();
}
...
var ser = new XmlSerializer(typeof(Receipt));
var obj = (Receipt)ser.Deserialize(source);

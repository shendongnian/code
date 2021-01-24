csharp
public class Bd
{
    [XmlElement("msg")]
    public Msg Msg { get; set; }
}
[XmlRoot("tr", Namespace = "http://www.fca.com/ifast")]
public class Tr
{
    [XmlElement("hd")]
    public Hd Hd { get; set; }
    [XmlElement("bd")]
    public Bd Bd { get; set; }
}
The two bits of XML you've included are semantically the same thing, but if you want to control the namespace prefix you can do this on serialisation:
csharp
var ns = new XmlSerializerNamespaces();
ns.Add("if", "http://www.fca.com/ifast");
var serializer = new XmlSerializer(typeof(Tr));
serializer.Serialize(stream, obj, ns);
See [this fiddle](https://dotnetfiddle.net/5Zqv8k) for a working demo.

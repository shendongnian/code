[XmlRoot(ElementName = "Dummy")]
public class Dummy
{
    [XmlElement(ElementName = "Definition")]
    public string Definition { get; set; }
    [XmlElement(ElementName = "Example")]
    public List<string> Example { get; set; }
}
**Usage:**
XmlSerializer serializer = new XmlSerializer(typeof(Dummy));
Dummy obj = (Dummy)serializer.Deserialize(new StreamReader(filename));
List<string> examples = obj.Example;
examples.ForEach(x => Console.WriteLine(x));
**Output**
0401010101010101
0401010101010101
0401010101010101
Definition and Example are two different element tags under Dummy tag. You will need to access them separately.
Also, look into [xml2csharp](www.xml2csharp.com) to convert your xml to c# classes.

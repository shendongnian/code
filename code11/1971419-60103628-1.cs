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
***
>**Alternate**
If you are looking to get the entire value within example, you will have to do something like this. Reason behind that is values are surrounded with <> which makes the value an element (without an end tag).
XDocument xdoc = XDocument.Parse(xmlString);
var objects = xdoc.Root.Elements().Where(x => x.Name.ToString().Equals("Example")).ToList();
objects.ForEach(x => Console.WriteLine(x.FirstNode.ToString()));
which produces the output of:
<![CDATA[0401010101010101]]>
<![CDATA[0401010101010101]]>
<![CDATA[0401010101010101]]>

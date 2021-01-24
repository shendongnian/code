//filename is the complete file name with path.
using TextReader reader = new StreamReader(filename);
XmlSerializer serializer = new XmlSerializer(typeof(Xmlentrees));
var allEntrees = (Xmlentrees)serializer.Deserialize(reader);
Entree starter = allEntrees.Entrees.Entree.FirstOrDefault(x => x.Nomentree.Equals("STATERNAME"));
if (starter != null)
{
    Console.WriteLine($"Name: {starter.Nomentree}, Desc: {starter.Descentree}, Recipe: {string.Join(",", starter.Recette)}");
}
**Classes needed for deserialization**
[XmlRoot(ElementName = "entree")]
public class Entree
{
    [XmlElement(ElementName = "Nomentree")]
    public string Nomentree { get; set; }
    [XmlElement(ElementName = "descentree")]
    public string Descentree { get; set; }
    [XmlElement(ElementName = "recette")]
    public string Recette { get; set; }
}
[XmlRoot(ElementName = "entrees")]
public class Entrees
{
    [XmlElement(ElementName = "entree")]
    public List<Entree> Entree { get; set; }
}
[XmlRoot(ElementName = "xmlentrees")]
public class Xmlentrees
{
    [XmlElement(ElementName = "entrees")]
    public Entrees Entrees { get; set; }
}
If you have xml files and you are not sure how the classes are supposed to be written, use [Xml2Csharp](https://xmltocsharp.azurewebsites.net/) site to automatically convert an xml to classes.

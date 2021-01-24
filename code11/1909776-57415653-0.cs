    public ProductData TestFunction()
    {
        ProductData result = new ProductData();
        string apiResponse = "API=3CProductData&XML=%3CProductData+Name%3D%22NameTest%22%3E%0D%0A++%3CId%3EXXXXXXXXX%3C%2FId%3E%0D%0A%3C%2FProductData%3E";
        string xml = HttpUtility.UrlDecode(apiResponse.Substring(apiResponse.IndexOf("XML=") + 4));
        XmlDocument document = new XmlDocument();
        document.LoadXml(xml);
        XmlNode newNode = document.DocumentElement;
        // Name is actually an attribute on the ProductData
        result.Name = ((XmlAttribute)newNode.Attributes["Name"]).InnerText;
        // Id is an actual node
        result.ID = ((XmlNode)newNode.FirstChild).InnerText;
        using (TextReader reader = new StringReader(xml))
        {
            var serializer = new XmlSerializer(typeof(ProductData));
            result = (ProductData)serializer.Deserialize(reader);
        }
        return result;
    }
[Serializable]
[XmlRoot("ProductData")]
public class ProductData
{
    [XmlElement("Id")]
    public string ID { get; set; }
    [XmlAttribute("Name")]
    public string Name { get; set; }
}
There is one very fragile part of this code, and I didn't spend a lot of time trying to do handle it.  The XML is not really well-formed in my opinion, so you're going to have to substring after the ```XML=``` which is why I added the +4 at the end of that.  Probably a smoother way to do it, but again the issue is really with converting the XML.  Since the XML is really simple, you can just target the values via SelectSingleNode.  If you want to go the StreamReader route, you need to make sure your class/properties have the attributes set up (i.e. [XmlRoot("Productdata")])

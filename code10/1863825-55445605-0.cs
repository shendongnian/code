    [XmlRoot(ElementName = "model", Namespace = "http://www.archimatetool.com/archimate")]
    [XmlType(Namespace = "http://www.archimatetool.com/archimate")]
    public class Model
    {
        [XmlElement(ElementName = "folder", Form = XmlSchemaForm.Unqualified)]
        public List<Folder> Folders { get; set; }
        [XmlElement(ElementName = "purpose", Form = XmlSchemaForm.Unqualified)]
        public string Purpose { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
    [XmlType(Namespace = "http://www.archimatetool.com/archimate")]
	public class Folder
	{
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "folder", Form = XmlSchemaForm.Unqualified)]
        public List<Folder> Folders { get; set; }
        [XmlElement(ElementName = "element", Form = XmlSchemaForm.Unqualified)]
        public List<Element> Element { get; set; }
	}
    [XmlType(Namespace = "http://www.archimatetool.com/archimate")]
	[XmlInclude(typeof(BusinessInterface))]
	public abstract class Element
	{
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
	}
    [XmlType(TypeName = "BusinessInterface", Namespace = "http://www.archimatetool.com/archimate")]
	public class BusinessInterface : Element
	{
	}

    public class DataStrings
    {
    	[XmlElement("ItemString")]
    	public List<Data> Value;
    }
    
    public class Data
    {
    	[XmlAttribute("id")]
    	public int id;
    
    	[XmlElement("Name")]
    	public string Name = null;
    
    	[XmlElement("ID")]
    	public int ID = 0;
    
    	[XmlElement("Description")]
    	public string Description;
    
    }
    
    public Dictionary<int, Data> Main(string path)
    {
    	var stringReader = new StringReader("<DataStrings><ItemString id=\"1\"><Name>Item 1</Name><ID>1</ID><Description>Item 1's description</Description></ItemString><ItemString id=\"2\"><Name>Berry</Name><ID>2</ID><Description>Item 2's description</Description></ItemString><ItemString id=\"3\"><Name>Shotgun</Name><ID>3</ID><Description>Item 3's description</Description></ItemString></DataStrings>");
    	XmlSerializer deserializer = new XmlSerializer(typeof(DataStrings), new XmlRootAttribute("DataStrings"));
    	var dict = ((DataStrings)deserializer.Deserialize(stringReader)).Value.ToDictionary(x => x.id, x => new Data() { ID = x.ID, Name = x.Name, Description = x.Description });
    	return dict;
    }

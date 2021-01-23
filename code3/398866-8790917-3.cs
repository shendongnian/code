    public class DeviceList : List<ListItem>
    {
       [XmlElement(ElementName = "type")]
       public string ListType {get;set;}
    
    }

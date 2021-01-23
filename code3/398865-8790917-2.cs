    public class SerializeMyStuff
    {
       public SeriazlieMyStuff()
       {
           ListOfDevices = new DeviceList();
           ListOfDevices.ListType = "list";
       }
       [XmlArray( "device_list" ), XmlArrayItem("item")]
       public DeviceList ListOfDevices {get;set;}
    }

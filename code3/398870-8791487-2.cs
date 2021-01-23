    var dlist = new DeviceList
                    {
                        Type = "list",
                        Items = new List<Item>
                                    {
                                        new Item {Type = "MAC", Value = "11:22:33:44:55:66:77:88"},
                                        new Item {Type = "MAC", Value = "11:22:33:44:55:66:77:89"},
                                        new Item {Type = "MAC", Value = "11:22:33:44:55:66:77:8A"},
                                    }
                    };
    
    
    using(FileStream stream = new FileStream(@"D:\jcoletest.xml", FileMode.Create, FileAccess.Write))
    {
        new XmlSerializer(typeof (DeviceList)).Serialize(stream, dlist);
    }

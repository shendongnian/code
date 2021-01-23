    var config = new Config
    {
        ValueOne = 23,
        ValueTwo = "Second Value",
        LotsOfValues = new[] { 23, 34, 34 },
        Other = new List<FurtherConfig> {
            new FurtherConfig { Value = 567},
            new FurtherConfig { Value = 98 }
        }
    };
    
    var serializer = new XmlSerializer(typeof(Config));
    
    //write out to file
    using (var fw = File.OpenWrite("config.xml"))
        serializer.Serialize(fw, config);
    
    //read in from file
    Config newConfig;
    using (var fr = File.OpenRead("config.xml"))
        newConfig = serializer.Deserialize(fr) as Config;
    
    Console.WriteLine(newConfig.Other[1].Value); //prints 98

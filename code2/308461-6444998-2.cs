    [Serializable]
    [XmlRoot]
    public class PowerBuilderRunTime
    {
     [XmlElement]
     public string Version {get;set;}
     [XmlArrayItem("File")]
     public string[] Files {get;set;} 
     
     public static PowerBuilderRunTime[] Load(string fileName)
     {
        PowerBuilderRunTime[] runtimes;
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var reader = new XmlTextReader(fs);
                runtimes = (PowerBuilderRunTime[])new XmlSerializer(typeof(PowerBuilderRunTime[])).Deserialize(reader);
            }
         return runtimes;
     }
    }

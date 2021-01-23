      [Serializable]
      public class MySettings  
      {
        public const string Extension = ".testInfo";
    
        [XmlElement]
        public string GUID { get; set; }
    
        [XmlElement]
        public bool TurnedOn { get; set; }
    
        [XmlElement]
        public DateTime StartTime { get; set; }
    
        public void Save(string filePath)
        {
          XmlSerializer serializer = new XmlSerializer(typeof(MySettings));
          TextWriter textWriter = new StreamWriter(filePath);
          serializer.Serialize(textWriter, this);
          textWriter.Close();
        }
    
        public static MySettings Load(string filePath)
        {
          XmlSerializer serializer = new XmlSerializer(typeof(MySettings));
          TextReader reader = new StreamReader(filePath);
          MySettings data = (MySettings)serializer.Deserialize(reader);
          reader.Close();
    
          return data;
        }
      }

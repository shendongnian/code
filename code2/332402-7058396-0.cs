    [DataContract]
    class RootObject
    {
      [DataMember(Name = "data")]
      public DataObject Data { get; set; }
    }
    [DataContract]
    class DataObject
    {      
      [DataMember(Name="translations")]
      public List<Translation> Translations { get; set; }
    }
    [DataContract]
    class Translation
    {
      [DataMember(Name = "translatedText")]
      public string TranslatedText { get; set; }
      [DataMember(Name = "detectedSourceLanguage")]
      public string DetectedSourceLanguage { get; set; }
    }

    public class PersonModel
        {
            [Key]
            [JsonProperty("ix")]
            [XmlElement("ix")]
            public int Index { get; set; }
    
            [XmlElement("content")]
            public ContentModel ContentModel { get; set; }
        }
    
        [ComplexType]//added
        [XmlRoot(ElementName = "content")]
        public class ContentModel
        {
            [JsonProperty("name")]
            [XmlElement("name")]
            public string Name { get; set; }
            [JsonProperty("visits")]
            [XmlElement("visits", IsNullable = true)]
            public int? Visits { get; set; }
            public bool ShouldSerializeVisits() { return Visits != null; }
            [JsonProperty("date")]
            public DateTime Date { get; set; }
            [NotMapped]//added
            [XmlElement("date")]
            public string dateRequested
            {
                get { return Date.ToString("yyyy-MM-dd"); }
                set { Date = DateTime.ParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); }
            }
        }

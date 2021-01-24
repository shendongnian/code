        public class Skills
        {
            [JsonProperty(PropertyName = ".Net")] //Add JsonProperty to include unclassified names
            public bool DotNet { get; set; }
            public string Mule { get; set; }
        }
        public class RootObject10
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public Skills Skills { get; set; }
        }

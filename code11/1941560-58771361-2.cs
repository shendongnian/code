    public class A {
        [JsonConverter(typeof(CascadeJsonConverter), // cascading converter
                       typeof(OptionJsonConverter), new object[0], // converter definition for the top-level type of the property
                       new object[] { // collection of converter definitions to use while deserializing the contents of the property
                           new object[] { typeof(DateFormatConverter), "yyyy'-'MM'-'dd'T'mm':'HH':'FF.ssK" }
                       })]
        public Option<DateTime> Time { get; set; }
    }

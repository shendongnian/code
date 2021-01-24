    namespace QuickType
    {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class Welcome
    {
        [JsonProperty("Options")]
        public Option[] Options { get; set; }
    }
    public partial class Option
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        [JsonProperty("University Name")]
        public string UniversityName { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Course")]
        public string Course { get; set; }
        [JsonProperty("Field of Study")]
        public string FieldOfStudy { get; set; }
        [JsonProperty("Course Language")]
        public string CourseLanguage { get; set; }
        [JsonProperty("Type of Institution")]
        public string TypeOfInstitution { get; set; }
    }
    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = 
                 DateTimeStyles.AssumeUniversal }
            },
        };
     }
    }

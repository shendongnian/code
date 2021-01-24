      public class TestRestResponseTemplate
      {
        public Entity Entity { get; set; }
      }
      public class LegalName
      {
        [JsonPropertyName("@xml:lang")]
        public string Language { get; set; }
    
        [JsonPropertyName("$")]
        public string Value { get; set; }
      }
    
      public class Entity
      {
        public LegalName LegalName { get; set; }
      }

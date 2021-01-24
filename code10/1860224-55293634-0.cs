      //data structure for mapping
      public class History {
        public string name { get; set; }
        public string department_name { get; set; }
        public string type { get; set; }
        public string department_id { get; set; }
      }
    var jsonString =
      @" {
        ""name"": ""use"",
        ""sender_type"": ""Trigger"",
        ""msg"": ""good morning"",
        ""type"": ""chat.msg""        
      }";
    
    History history = JsonConvert.DeserializeObject<History>(jsonString);

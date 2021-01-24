      //data structure for mapping
      public class History {
        public string name { get; set; }
        public string department_name { get; set; }
        public string type { get; set; }
        public string department_id { get; set; }
      }
      var jsonString =
        @"[ {
            ""name"": ""fdef"",
            ""sender_type"": ""Trigger"",
            ""msg"": ""Welcome back! How may I help you today?"",
            ""type"": ""chat.msg""        
          }, {
            ""name"": ""use"",
            ""sender_type"": ""Trigger"",
            ""msg"": ""good morning"",
            ""type"": ""chat.msg""        
          }
        ]";
      List<History> history = JsonConvert.DeserializeObject<List<History>>(jsonString);
      var messages = history
        .Select(x => x.msg)
        .ToList();

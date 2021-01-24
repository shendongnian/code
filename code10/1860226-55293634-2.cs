      //data structure for mapping
    public class History {
      public string name { get; set; }
      public string sender_type { get; set; }
      public string msg { get; set; }
      public string type { get; set; }
    }
    
    public class Visitor {
      public string Phone { get; set; }
      public string Name { get; set; }
    }
    
    
    public class ObjectThatContainsHistory {
      public string Comment { get; set; }
      public bool Triggered_Response { get; set; }
      public string Rating { get; set; }
      public Visitor Visitor { get; set; }
    
      public List<History> History { get; set; }
    }
      var jsonString =
        @"{
            ""comment"": null,
            ""triggered_response"": true,
            ""rating"": null,
            ""visitor"": {
              ""phone"": """",
              ""name"": ""abc""
            },
            ""history"": [
              {
                ""name"": ""Visitor 7949"",
                ""department_name"": null,
                ""type"": ""chat.memberjoin"",
                ""department_id"": null
              },
              {
                ""name"": ""fdef"",
                ""sender_type"": ""Trigger"",
                ""msg"": ""Welcome back! How may I help you today?"",
                ""type"": ""chat.msg""        
              },
              {
                ""name"": ""use"",
                ""sender_type"": ""Trigger"",
                ""msg"": ""good morning"",
                ""type"": ""chat.msg""        
              }
            ]
        }";
      ObjectThatContainsHistory objectThatContainsHistory = JsonConvert.DeserializeObject<ObjectThatContainsHistory>(jsonString);
      var messages = objectThatContainsHistory.History
        .Select(x => x.msg)
        .ToList();

        public class UrlStatus
        {
          public int Status { get; set; }
          public string Url { get; set; }
        }
    
    
        [Test]
        public void GenericDictionaryObject()
        {
          Dictionary<string, object> collection = new Dictionary<string, object>()
            {
              {"First", new UrlStatus{ Status = 404, Url = @"http://www.bing.com"}},
              {"Second", new UrlStatus{Status = 400, Url = @"http://www.google.com"}}
            };
    
          string json = JsonConvert.SerializeObject(collection, Formatting.Indented, new JsonSerializerSettings
          {
            TypeNameHandling = TypeNameHandling.Objects,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
          });
    
          Assert.AreEqual(@"{
      ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[System.Object, mscorlib]], mscorlib"",
      ""First"": {
        ""$type"": ""Newtonsoft.Json.Tests.Serialization.TypeNameHandlingTests+UrlStatus, Newtonsoft.Json.Tests"",
        ""Status"": 404,
        ""Url"": ""http://www.bing.com""
      },
      ""Second"": {
        ""$type"": ""Newtonsoft.Json.Tests.Serialization.TypeNameHandlingTests+UrlStatus, Newtonsoft.Json.Tests"",
        ""Status"": 400,
        ""Url"": ""http://www.google.com""
      }
    }", json);
    
          object c = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
          {
            TypeNameHandling = TypeNameHandling.Objects,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
          });
    
          Assert.IsInstanceOfType(typeof(Dictionary<string, object>), c);
    
          Dictionary<string, object> newCollection = (Dictionary<string, object>)c;
          Assert.AreEqual(2, newCollection.Count);
          Assert.AreEqual(@"http://www.bing.com", ((UrlStatus)newCollection["First"]).Url);
        }

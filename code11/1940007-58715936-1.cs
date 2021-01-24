        public class RootObject
        {
            public string field1 { get; set; }
            public dynamic nested { get; set; }  
            
            public List<NestedObject> NestedObjects
            {
                get
                {
                   if(nested is JArray)
                   {
                        return JsonConvert.DeserializeObject<List<NestedObject>>(nested.ToString());
                   }
                    
                   var obj = JsonConvert.DeserializeObject<NestedObject>(nested.ToString());
                   return new List<NestedObject> { obj };
                }
            }
        }
        public class NestedObject
        {
            public string nestedField { get; set; }
        }

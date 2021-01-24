             public class Example
              {
                public int Index { get; set; }
                public string[] B { get; set; }
                public string[] S { get; set; }
              }   
                
                   var strData = @"{'i': 5, 'b0': 'ABC','b1': 'DEF', 'b2': 'GHI', 's0': 'SABC', 's1': 'SDEF', 's2': 'SGHI',}";
                   var data = JsonConvert.DeserializeObject<JToken>(strData).Values().ToList();
                   Example result = new Example();
                   result.Index = data.Values().FirstOrDefault(x => x.Path == "i").Value<int>();
                    result.B = data.Values().Where(x => x.Path.StartsWith("b")).Select(x => x.Value<string>()).ToArray();
                    result.S = data.Values().Where(x => x.Path.StartsWith("s")).Select(x => x.Value<string>()).ToArray();
                
           

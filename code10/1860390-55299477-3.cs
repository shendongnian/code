    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApp2 {
      class Program {
        static void Main() {
    
          string json = @"[{'DocType' : 'MSWORD','DocId'   : '553ed6c232da426681b7c45c65131d33'},{'DocType' : 'MSEXCEL','DocId'   : '256ed6c232da426681b7c45c651317895'}]";
          Request.Seed = 1;
          var r = JsonConvert.DeserializeObject<List<Request>>(json);
          Request.Seed = 100000;
          r = JsonConvert.DeserializeObject<List<Request>>( json );
    
        }
      }
      public class Request {
        public static int Seed { get; set; }
    
        public Request() {
          Index = Seed++;
        }
        public int Index { get; set; }
        public string DocType { get; set; }
        public string DocId { get; set; }
      }
    }

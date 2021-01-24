    using System.Text.Json.Serialization;
    using Newtonsoft.Json;
    
    public class C {
      public C() { }
      public string PracticeName { get; set; }
    }
    
    var x = new C("1");
    var json = JsonConvert.SerializeObject(x); // returns "{\"PracticeName\":\"1\"}"
    
    var x1 = JsonConvert.DeserializeObject<C>(json); // correctly builds a C
    
    var x2 = System.Text.Json.Serialization.JsonSerializer.Parse<C>(json);

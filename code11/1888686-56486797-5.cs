    using Newtonsoft.Json;
    
    namespace TestJsonParse
    {
        class Program
        {
            static void Main(string[] args)
            {
                var c1 = new C1("1");
                var json1 = JsonConvert.SerializeObject(c1); // returns "{\"PracticeName\":\"1\"}"
                var x1 = JsonConvert.DeserializeObject<C1>(json1); // correctly builds a C1
    
                var c2 = new C2();
                string json2 = "{\"PracticeName\":\"1\"}";
                var x2 = System.Text.Json.Serialization.JsonSerializer.Parse<C2>(json2); // correctly builds a C2
            }
    
            class C1
            {
                public C1(string PracticeName) { this.PracticeName = PracticeName; }
                public string PracticeName;
            }
    
            class C2
            {
                public C2() { }
                public string PracticeName { get; set; }
            }
        }
    }

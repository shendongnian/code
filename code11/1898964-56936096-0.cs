    class Cls
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        [JsonIgnore]
        public string prop3 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cls = new Cls
            {
                prop1 = "lorem",
                prop2 = "ipsum",
                prop3 = "dolor"            
            };
            System.Console.WriteLine(JsonConvert.SerializeObject(cls));
            //Output: {"prop1":"lorem","prop2":"ipsum"}
        }
    }

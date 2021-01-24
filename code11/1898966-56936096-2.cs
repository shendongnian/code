    class Cls
    {
        public List<string> prop1 { get; set; }
        public List<string> prop2 { get; set; }
        public List<string> prop3 { get; set; }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            prop3 = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cls = new Cls
            {
                prop1 = { "lorem", "ipsum", "dolor" },
                prop2 = { "lorem", "ipsum", "dolor" },
                prop3 = { "lorem", "ipsum", "dolor" },
            };
            System.Console.WriteLine(JsonConvert.SerializeObject(cls)); //Output: 
        }
    }

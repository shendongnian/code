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
                prop1 =  new List<string>{ "lorem", "ipsum", "dolor" },
                prop2 =  new List<string>{ "lorem", "ipsum", "dolor" },
                prop3 =  new List<string>{ "lorem", "ipsum", "dolor" },
            };
            System.Console.WriteLine(JsonConvert.SerializeObject(cls)); //Output: {"prop1":["lorem"],"prop2":["lorem"],"prop3":null}
        }
    }

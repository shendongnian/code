    class SnData
    {
        public string Value1 {get; set;}
        public string Value2 {get; set;}
        public int Count {get; set;}
    }
      class Program
    {
        static void Main(string[] args)
        {
            string json1 = File.ReadAllText("test.json");
            var info = JsonSerializer.Deserialize<SnData>(json1);
            WriteLine("Value1: {0} , Value2: {1}, Count: {2}",info.Value1,info.Value2, info.Count);
        }
    }

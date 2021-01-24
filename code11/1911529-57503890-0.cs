    class Program
    {
        static void Main(string[] args)
        {
            var text = "{ \"$type\": \"Type1\",\"mapping\": [ { \"value\": \"Value1\", \"key\": \"Key1\" }, { \"value\": \"Value2\", \"key\": \"Key2\" } ] }";
            dynamic result = JsonConvert.DeserializeObject(text);
            dynamic mapping = result.mapping;
            foreach(dynamic item in mapping as IEnumerable<dynamic>)
            {
                Console.WriteLine("{0}: {1}", (string)item.value, (string)item.key);
            }
            var done = Console.ReadLine();
        }
    }

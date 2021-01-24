    class ItemClass
    {
        public int Id;
        public string Name;
    }
    class ListInfo
    {
        public int Info1 { get; set; }
        public string Info2 { get; set; }
    }
    class ItemCol
    {
        public List<ItemClass> ItemList { get; set; }
        public ListInfo ListInfo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var output = "{\"itemList\":[{\"id\":1,\"name\":\"Item 1 Name\"},{\"id\":2,\"name\":\"Item 2 Name\"}], \"listInfo\": {\"info1\":1,\"info2\":\"bla\"}}";
            var results = JsonConvert.DeserializeObject<ItemCol>(output);
            Console.WriteLine("Hello World!");
        }
    }

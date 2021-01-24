    class Master
    {
        public List<Item> Items { get; set; } = new List<Item>() { new Item(1), new Item(2) };
    }
    class Item
    {
        public Item(int x)
        {
            this.X = x;
        }
        public int X { get; set; }
    }
    public static void Main(string[] args)
    {
        var masters = new List<Master>();
        masters.Add(new Master());
        masters.Add(new Master());
        List<int> xList = masters.Select(s => s.Items).SelectMany(s => s, (m, i) => i.X).ToList();
        foreach (int item in xList)
        {
            Console.WriteLine(item);
        }
    }

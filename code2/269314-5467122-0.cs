    class Item
    {
        public int Value { get; set; }
    }
    var list = new List<Item>();
    var avg = list.Average(item => item.Value);

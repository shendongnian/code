    public class CategoryModel
    {
        public string Label { get; set; }
        public bool Active { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public string Type { get; set; }
        public List<ItemModel> Items { get; set; }
    }

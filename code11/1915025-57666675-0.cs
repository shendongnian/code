    public class Item
    {
        public string Data { get; set; }
        public List<string> AssociatedData { get; set; } = new List<string>();
        // This returns a comma-separated line representing this item
        public string GetCsvString()
        {
            return $"{Data},{string.Join(",", AssociatedData)}";
        }
    }

    public class MyViewModel
    {
        public int? SelectedItemValue { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
    public class Item
    {
        public int? Value { get; set; }
        public string Text { get; set; }
    }

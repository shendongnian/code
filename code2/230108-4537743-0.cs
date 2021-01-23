    public class SliderViewModel
    {
        public string SelectedSpeed { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
    public class Item
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

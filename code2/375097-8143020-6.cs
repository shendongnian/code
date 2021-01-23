    public class ItemViewModel
    {
        public string Title { get; set; }
    }
    public class MyViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
    }

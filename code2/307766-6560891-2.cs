    namespace WpfTreeViewBinding.Model
    {
        public class DirectoryItem : Item
        {
            public List<Item> Items { get; set; }
    
            public DirectoryItem()
            {
                Items = new List<Item>();
            }
        }
    }

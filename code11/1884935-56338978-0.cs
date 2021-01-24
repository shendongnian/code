    public class Item
    {
        public bool IsChecked { get; set; }
        // other properties like ID, File, Author
    }
    public class ViewModel
    {
        public ObservableCollection<Item> Items { get; }
            = new ObservableCollection<Item>();
    }

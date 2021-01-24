    public class SortedItem : ObservableCollection<Item>
    {
        public string Header { get; set; }
    
        public SortedItem(List<Item> list) : base(list)
        {
                
        }
    }

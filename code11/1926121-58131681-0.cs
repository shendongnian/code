    public class ParentItems : ObservableCollection<ChildItems>
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public ParentItems(List<ChildItems> list) : base(list)
        {
        }
    }

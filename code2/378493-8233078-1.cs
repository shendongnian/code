    public class ViewModel
    {
        public ViewModel()
        {
            Src = new ObservableCollection<Item>() { new Item { Id = 1, Name = "A" }, new Item { Id = 2, Name = "B" } };
        }
        public ObservableCollection<Item> Src { get; set; }
    }
    public class Item{
        public int Id { get; set; }
        public string Name { get; set; }
    }

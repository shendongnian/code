    public class ItemsList : ObservableCollection<Item>
    {
        public ItemsList() : base()
        {
            Add(new Item("item 1", 100));
            Add(new Item("item 2", 120));
            Add(new Item("item 3", 140));
            Add(new Item("item 4", 160));
        }
      }

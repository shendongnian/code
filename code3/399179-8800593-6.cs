    public ObservableCollection<Item> Items
    {
      get
      {
        return new ObservableCollection<Item>()
                 {
                   new Item() {DisplayValue = "Item1", IsSelected = false, Sample = "Sample: I am Item1"},
                   new Item() {DisplayValue = "Item2", IsSelected = true, Sample = "Sample: I am Item2"},
                   new Item() {DisplayValue = "Item3", IsSelected = false, Sample = "Sample: I am Item3"}
                 };
      }
    }

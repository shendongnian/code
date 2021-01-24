    class ViewModel
    {
      public ViewModel()
      {
        this.ParentItems = new ObservableCollection<DataItem>()
        {
          new DataItem("Ben Stiller") { ChildItems = new ObservableCollection<DataItem>() { new DataItem("Zoolander"), new DataItem("Tropical Thunder") }},
          new DataItem("Al Pacino") { ChildItems = new ObservableCollection<DataItem>() { new DataItem("Scarface"), new DataItem("The Irishman") }},
          new DataItem("Keanu Reeves") { ChildItems = new ObservableCollection<DataItem>() { new DataItem("John Wick"), new DataItem("Matrix") }},
          new DataItem("Bryan Cranston") { ChildItems = new ObservableCollection<DataItem>() { new DataItem("Breaking Bad"), new DataItem("Malcolm in the Middle") }}
        };
      }
    
      private void FilterData(string filterPredicate)
      {
        CollectionViewSource.GetDefaultView(this.SelectedParentItem.ChildItems).Filter =
            item => (item as DataItem).Name.StartsWith(filterPredicate, StringComparison.OrdinalIgnoreCase);
      }
    
      private string searchPredicate;   
      public string SearchPredicate
      {
        get => this.searchFilter;
        set 
        { 
          this.searchPredicate = value;
          FilterData(value);
        }
      }
    
      public ObservableCollection<DataItem> ParentItems { get; set; }
      public DataItem SelectedParentItem { get; set; }
    }

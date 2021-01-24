    class DataItem
    {
      public DataItem(string Name)
      {
        this.Name = name;
      }
    
      public string Name { get; set; }
      public ObservableCollection<DataItem> ChildItems { get; set; }
    }

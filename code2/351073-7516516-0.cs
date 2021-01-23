    var myDataSource = ...;
    public void DeleteItem(Item item)
    {
      item.RunTimeState = RunTimeState.Deleted;
      // you can remove the item from the myDataSource here or filter it later
      PropertyChanged(this, new PropertyChangedEventArgs("DataSource"));
    }
    public IList<Item> DataSource 
    {
      get { return myDataSource; }
      // or
      get 
      { 
        return myDataSource.Where(i => i.RunTimeState != RunTimeState.Deleted).ToList(); 
      }
    }

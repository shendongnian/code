    public ObservableCollection<Thing> MyList1 { get; set; }
    public ObservableCollection<Thing> MyList2 { get; set; }
    // these properties should raise property changed events (INotifyPropertyChanged)
    public Thing SelectedList1Item { get {...} set {...} }
    public Thing SelectedList2Item { get {...} set {...} }
    // constructor 
    public MyViewModel()
    {
      // instantiate and populate lists
      this.MyList1 = new ObservableCollection(this.service.GetThings());
      this.MyList2 = new ObservableCollection(this.service.GetThings());
    } 

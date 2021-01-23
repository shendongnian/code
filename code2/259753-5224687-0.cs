    public ObservableCollection<MyObject> MyCollection
    {
       get
       {
          return _myCollection;
       }
       set
       {
          _myCollection = value;
          RaisePropertyChanged("MyCollection");
       }
    } 

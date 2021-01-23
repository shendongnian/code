    public string SelectedStoreName
    {
       get { return _storeName; }
       set {
          if (!Equals(value, _storeName))
          {
             _storeName = value;
             _currentStore = FindStore(value);
             OnPropertyChanged("SelectedStoreName"); // invokes INotifyPropertyChanged
             OnPropertyChanged("AvaiableAisles");
          }
       }
    }
    
    public IEnumerable<Aisles> AvaiableAisles
    {
        get { return _currentStore.StoreAisles.ToArray(); }
    }
    /* same with the rest of your chain */

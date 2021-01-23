    public ObservableCollection<string> ButtonData
    {
      get { return buttonData; }
      set 
      { 
        buttonData.CollectionChanged -= buttonData_CollectionChanged;
        buttonData = value;
        buttonData.CollectionChanged += buttonData_CollectionChanged;
      }
    }

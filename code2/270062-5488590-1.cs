    public ObservableCollection<string> ButtonData
    {
      get { return buttonData; }
      set 
      { 
        if (buttonData != null) {
          buttonData.CollectionChanged -= buttonData_CollectionChanged;
        }
        buttonData = value;
        if (buttonData != null) {
          buttonData.CollectionChanged += buttonData_CollectionChanged;
        }
      }
    }

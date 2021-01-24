    public ObservableCollection<Object> SelectedFirmwares
    {
        get 
        {
          return _selectedFirmwares;                
        }
        set
        {
          if (object.Equals(value, selectedFirmwares))
              return;
          _selectedFirmwares = value;
          OnPropertyChanged();
        }
    }

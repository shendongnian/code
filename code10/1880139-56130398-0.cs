    private Car _myCar;
    public Car MyCar
    {
        get { return _myCar; }
        set
        {
            if (_myCar != null && _myCar.Manufacturer != null)
                _myCar.Manufacturer.PropertyChanged -= OnManufacturerPropertyChanged;
            _myCar = value;
            NotifyOfPropertyChange(() => CanSaveSelection);
            if (_myCar != null && _myCar.Manufacturer != null)
                _myCar.Manufacturer.PropertyChanged += OnManufacturerPropertyChanged;
        }
    }
    private void OnManufacturerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        NotifyOfPropertyChange(nameof(CanSaveSelection));
    }

    public string DisplayValue { get; set; }
    private bool _isSelected = false;
    public bool IsSelected
    {
      get
      {
        return _isSelected;
      }
      set
      {
        _isSelected = value;
        OnPropertyChanged("IsSelected");
      }
    }
    private string _sample;
    public string Sample
    {
      get
      {
        return _sample;
      }
      set
      {
        _sample = value;
        OnPropertyChanged("Sample");
      }
    }

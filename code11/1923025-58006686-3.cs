    public enum Fruits { Apple, Orange, Pear, Grape }
    private Fruits _selectedFruit;
    public Fruits SelectedFruit
    {
      get { return _selectedFruit; }
      set
      {
        _selectedFruit = value;
        OnPropertyChanged(nameof(SelectedFruit));
      }
    }
  

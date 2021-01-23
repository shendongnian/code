    private string _grade;
    public string Grade
    {
      get { return _grade; }
      set
      {
        if (_grade == value)
          return;
        _grade = value;
        OnPropertyChanged("Grade");
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string property)
    {
      if (PropertyChanged!=null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
      }
    }

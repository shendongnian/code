    private List<string> _titleList;
    public List<string> TitleList
    {
      get => _titleList;
      set
      {
        // if the new value is the same as the old, just do nothing
        if (Equal(_titleList, value))
          return;
        _titleList = value;
        // This call will raise the event
        NotifyPropertyChanged();
      }
    } 

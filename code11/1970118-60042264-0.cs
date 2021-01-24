    // this is an auto-property
    public List<string> TitleList { get; set; }
    // it's equivalent to:
    private List<string> _titleList;
    public List<string> TitleList
    {
      get => _titleList;
      set => _titleList = value;
    }    

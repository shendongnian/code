    private List<string> actualList = new List<string();
    public ReadOnlyCollection<string> myList
    {
      get{ return actualList.AsReadOnly();}
    }

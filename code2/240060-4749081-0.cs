    private List<string> myList;
    
    public IList<string> MyList
    {
      get{return myList.AsReadOnly();}
    }

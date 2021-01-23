    private List<string> myList;
    
    public List<string> MyList
    {
        get { return myList.AsReadOnly().ToList(); }
    }

    private List<string> namesList;
    public List<string> NameList {
      { 
        get { 
          if ( namesList == null ) namesList = new List<string>();
          return namesList;
        }
    }

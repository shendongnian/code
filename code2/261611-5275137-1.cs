    private List<string> descriptions = whatever;
    public IList<string> SpillageListDescriptions 
    { 
        get 
        {
            return new ReadOnlyCollection<string>(descriptions); 
        }
    }
    

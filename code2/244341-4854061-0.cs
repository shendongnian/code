    private List<string> someStrings = null;
    public List<string> SomeStrings {
        get {
            if (someStrings == null)
                someStrings = new List<string>();
            return someStrings;
        }
    }
    
    public bool HasSomeStrings {
        get { return someStrings != null; }
    }

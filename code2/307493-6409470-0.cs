    // note: doesn't work; see answer text
    private List<string> conflictList;
    public List<String> ConflictList
    {
        get { return conflictList ?? (conflictList = new List<string>()); }
    }

    public IEnumerable<string> Tags 
    {
        get
        {
            return TagsSet.Select(t => t.Tag);
        }
    }

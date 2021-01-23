    private static List<string> Precedence = new List<string>() { "item1", "item2", "item3" }; // etc
    
    public int CompareTo(object obj)
    {
        Filter item = obj as Filter; // Assume not null.   
        int otherIndex = Precedence.IndexOf(item.FilterValue);
        int thisIndex = Precedence.IndexOf(this.FilterValue); // Assume 'this' is a Filter
    
        // This may need to be otherIndex.CompareTo(thisIndex) depending on the direction of sort you want.
        return thisIndex.CompareTo(otherIndex);
    }

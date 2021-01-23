    public void processTheList(List<string> someList = null)
    {
        // Instead of special-casing null, make your code cleaner
        var list = someList ?? Enumerable.Empty<string>();
        // Now we can always assume list is a valid IEnumerable
        foreach(string item in list) { /* ... */ }
    }

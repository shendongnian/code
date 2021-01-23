    public ILookup<int, MyClass> GetIndexedGroups(string group)
    {
        return myList.Where(a => a.Group == group)
                    .ToLookup(n => n.GroupIndex);                    
    }

    public InheritModel Merge(InheritModel current, InheritModel orig)
    {
        var result = new InheritModel();
        if (current.Id != orig.Id) 
        {
            result.Id = current.Id;
        }
        if (current.Name != orig.Name) 
        {
            result.Name = current.Name;
        }
        ... for the other properties
        return result;
    }

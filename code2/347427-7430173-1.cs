    List<string> AddDashesToList(List<string> list)
    {
        var newList = new List<string>();
    
        foreach(item in list)
        {
           newList.Add(item);
           newList.Add("-");
        }
        
        newList.RemoveAt(newList.Count-1);
        return newList;
    }

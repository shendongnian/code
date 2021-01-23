    public List<Document> GetConsecutiveTrueDocs(List<Document> list)
    {
        var result = new List<Document>();
    
        if(list.Count < 2)
            return result;
    
        for(int i = 1; i < list.Count; i++)
        {
            if(list[i].IsValid && list[i-1].IsValid)
            {
                if(!result.Contains(list[i-1]))
                    result.Add(list[i-1]);
                result.Add(list[i]);
            }
        }
    
        return result;
    }

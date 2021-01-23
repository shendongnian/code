    public static List<List<DictionaryEntry>> ChunkDict(Dictionary<string,string> theList, int chunkSize)  
    {  
        List<List<DictionaryEntry>> result = theList.Select((x, i) =>  
            new { data = x, indexgroup = i / chunkSize }) 
            .GroupBy(x => x.indexgroup, x => x.data) 
            .Select(g => new List<DictionaryEntry>(g.ToList())).ToList();  
        return result;  
    }  

    public List<string> GetpathsById(List<long> id)  
    {
        List<string> paths = new List<string>();  
        foreach(long aa in id)  
        {  
            Presentation press = context.Presentations.Where(m => m.PresId == aa).FirstOrDefault();  
            paths.Add(press.FilePath);  
        }  
        return paths;  
    }  

    public string ShrinkPath(string path, int maxLength)
    {
        List<string> parts = new List<string>(path.Split(@"\"));
    
        string start = parts[0] + @"\" + parts[1];
        parts.RemoveAt(1);
        parts.RemoveAt(0);
    
        string end = parts[parts.Count-1];
        parts.RemoveAt(parts.Count-1);
    
        parts.InsertAt(0, "...");
        while(parts.Count > 1 && 
          start.Length + end.Length + parts.Sum(p=>p.Length) + parts.Count > maxLength)
            parts.RemoveAt(parts.Count-1);
    
        string mid = "";
        parts.ForEach(p => mid += p + @"\");
    
        return start+mid+end;
    }

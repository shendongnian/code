    var sections = new Dictionary<string, List<string>>();
    
    foreach(var it in uploadBox.Items)
    {
        var item = it.ToString();
    
        if(item.Contains("Section"))
        {
    
            var section = GetSection(item);
    
            if(!sections.ContainsKey(section))
            {
                sections.Add(section, new List<string>());            
            } 
            
            sections[section].Add(item);
        }    
    }
    
    private string GetSection(string item)
    {
        var split = item.Split("_");
        return $"{split[1]}_{split[2]}";    
    }

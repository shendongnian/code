    List<string> lines ; // load lines form file
    
    Dictionary<string,List<string>> dic = new Dictionary<string,List<string>>();
    foreach(string line in lines) 
    {
        string key = line.Split('|')[0];
    
        if(!dic.ContainsKey(key))
            dic.Add(key,new List<string>{line});
        else 
            dic[key].Add(line) 
    }
    
    foreach(var pair in dic) 
    {
        //create file and store there pair.Value   
    }

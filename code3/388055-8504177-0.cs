    string data = "first, middle, middle, middle, middle, last";
    
    string[] splitData = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
    Dictionary<string, string> splits = new Dictionary<string, string>();
    
    foreach (var s in splitData)
    {
        var temp = s.Trim();
        if (splits.ContainsKey(temp))
        {
            splits[temp] += ", " + temp;
        }
        else
        {
            splits[temp] = temp;
        }
    }
    
    string[] result = splits.Select(y => y.Value).ToArray();

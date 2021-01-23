    var tagList = new List<string>();
                     string pattern = @"(?<=</?)([^ >/]+)"
                     var matches = Regex.Matches(file, pattern);
    
    for (int i = 0; i < matches.Count; i++)
                     {
    
                         tagList.Add(matches[i].ToString());
    
                     }
                         //to obtain non duplicate list
                         tagList = tagList.Distinct().ToList();

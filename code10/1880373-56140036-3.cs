    var result = Speach.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => Regex.Replace(x.ToLower(), "[^a-zA-Z0-9-]", ""))
                       .GroupBy(x => x)
                       .ToDictionary(x => x.Key, x => x.Count());
    
    Print(result.OrderByDescending(x => x.Value).ToList());

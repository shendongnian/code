    var perms = "[[`notes`,1],[`logs`,1],[`superUser`,1]]"; // Assuming the format is always the same...
    var results = perms.Split("],")
                       .Select(x => x.Replace("`", string.Empty)
                                     .Replace("[", string.Empty)
                                     .Replace("]", string.Empty))
                       .Select(c => new KeyValuePair<string, bool>(c.Split(',')[0].Trim(), c.Split(',')[1].Trim() == "1"))
                       .ToDictionary(x => x.Key, x => x.Value);

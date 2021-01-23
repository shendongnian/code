    var values  = data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                      .Select(line => line.Split(":".ToCharArray(), 2))
                      .ToDictionary(pair => pair[0], pair => pair[1], 
                                    StringComparer.OrdinalIgnoreCase);
    string name = values["name"];

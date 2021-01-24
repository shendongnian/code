    string[] wordme = { "me", "myself", "i" };
    
    var mapping = new Dictionary<(string key, int ID), Action<string>>
                   { { ("me", 0), s => Me(s) },
                     { ("myself", 1), s => Myself(s) },
                     { ("i", 2), s => I(s) } };
    
    for (var i = 0; i < wordme.Length; i++)
       if (mapping.TryGetValue((wordme[i], i), out var action))
          action(wordme[i]);

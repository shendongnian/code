    var characterCodes = new List<int>();
    foreach(var c in S)
    {
        if((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
        {
            characterCodes.Add((int)c);
        }
    }

    var characterCodes = new List<int>();
    foreach(var c in S)
    {
        if(char.IsLetter(c))
        {
            characterCodes.Add((int)c);
        }
    }

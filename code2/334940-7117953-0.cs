    string[] split = ("North Korea").Split(' ');
    string newString = "";
    for (int i = 0; i < split.Count(); i++)
    {
        if (i == 0)
            newString += split[i].ToLower();
        else
            newString += split[i];
    }

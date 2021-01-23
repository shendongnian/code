    string[] split = ("North Korea").Split(' ');
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < split.Count(); i++)
    {
        if (i == 0)
            sb.Append(split[i].ToLower());
        else
            sb.Append(split[i]);
    }

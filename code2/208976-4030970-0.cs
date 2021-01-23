    StringBuilder sb = new StringBuilder();
    foreach (var char in mystring)
    {
        char replace;
        if (hash.TryGetValue(char, out replace))
        {
            sb.Append(replace);
        }
        else
        {
            sb.Append(char);
        }
    }

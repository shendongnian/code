    var str = new StringBuilder();
    for (int c = Console.Read(); c != -1; c = Console.Read())
    {
        if (c == '\n' || c == '\r')
            continue;
        str.Append((char)c);
    }
    string s = str.ToString();

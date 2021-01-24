    string url = null;
    foreach (string line in sql.Split('\n'))
    {
        if (line.ToLower().StartsWith("http"))
        {
            url = line;
            break;
        }
    }
    if (url != null) //You found a url

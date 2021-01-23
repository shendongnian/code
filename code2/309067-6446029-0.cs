    List<string> firstNames = new List<string>();
    firstNames.Add("John");
    firstNames.Add("Mary");
    firstNames.Add("Jane");
    int cnt = 0;
    string names = string.Empty;
    while (cnt<=firstName.Count)
    {
        string separator = "";
        if (firstName.Count - cnt > 1) separator = ", ";
        else if (firstName.Count - cnt = 1) separator = ", and ";
        else separator = "";
        names += firstName[cnt] + separator;
        cnt += 1;
    }

    List<string> parts = new List<String>();
    foreach(string split in mystring.Split(','))
        if(!parts.Contains(split))
            parts.Add(split);
    string newstr = "";
    foreach(string part in parts)
        newstr += part + ",";

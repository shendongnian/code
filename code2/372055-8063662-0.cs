    foreach (KeyValuePair<string, string> kvp in dict)
    {
        _savedxml.Add(kvp.Key.ToString());
    }
    string namewithext = null;
    int i = 0;
    while (i < _savedxml.Count)
    {
        namewithext = string.Concat(_savedxml[i], ".xml");
        System.IO.FileInfo file_info = new System.IO.FileInfo((string)namewithext);
        if (!file_info.Exists || file_info.Length == 0)
            _savedxml.RemoveAt(i);
        else
            i++;
    }

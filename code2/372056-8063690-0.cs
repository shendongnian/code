    foreach (KeyValuePair<string, string> kvp in dict) {
      _savedxml.Add(kvp.Key);
    }
    for (int i = _savedxml.Count - 1; i >= 0 ; i--) {
      string namewithext = _savedxml[i] + ".xml";
      if (!System.IO.File.Exists(System.IO.Path.GetFullPath(namewithext))) {
        _savedxml.RemoveAt(i);
      }
    }
    for (int i = _savedxml.Count - 1; i >= 0 ; i--) {
      string namewithext = _savedxml[i] + ".xml";
      System.IO.FileInfo file_info = new System.IO.FileInfo(namewithext);
      if (file_info.Length == 0) {
        _savedxml.RemoveAt(i);
      }
    }

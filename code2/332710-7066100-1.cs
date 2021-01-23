    StringBuilder sb = new StringBuilder();
    foreach (string key in mycollection.Keys)
    {
       sb.Append(string.Format("{0}{1}={2}",
          sb.Length == 0 ? string.Empty : "&",
          key,
          mycollection[key]));
    }
    string nameValueString = sb.ToString();

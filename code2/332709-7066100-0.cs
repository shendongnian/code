    StringBuilder sb = new StringBuilder();
    
    for (int i = 0; i < mycollection.Count; i++)
    {
       sb.Append(string.Format("{0}{1}={2}", 
          i == 0 ? string.Empty : "&",
          mycollection.Keys[i], 
          mycollection[mycollection.Keys[i]]));
    }
    
    string nameValueString = sb.ToString();

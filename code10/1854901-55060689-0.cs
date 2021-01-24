    for(int i=lines.Count - 1; i > -1; i--)
    {
     if (lines[i].Contains(searchItem))
      {
        lines.RemoveAt(i);
      }
    }

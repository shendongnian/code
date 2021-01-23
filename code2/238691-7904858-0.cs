    int i = 0;
    while(i < lines.Count)
    {
      if (lines[i].FullfilsCertainConditions())
      {
         lines.RemoveAt(i);
      }
      else {i++;}
    }

    List<string> a = GetNamesFromeSomewhere();
    
    bool duplicateFound = true;
    while (duplicateFound )
    {
      duplicateFound = false;
      for (int x = 0; x < a.Length; x++)
      {
        for (int y = x + 1; y < a.Length; y++)
        {
          if (a[x].Equals(a[y]))
          {
            //Change a[y], but now we have to recheck for duplicates...
            a[y] += "_";
            duplicateFound = true;
            break;
          }
        }
        if (duplicateFound)
        {
          break;
        }
      }
    }

    public static String[] StringToWords(String str, HashSet<string> words)
    {      
      //Index of char - length of last valid word
      int[] bps = new int[str.Length + 1];
      
      for (int i = 0; i < bps.Length; i++)      
        bps[i] = -1;
      
      for (int i = 0; i < str.Length; i++)
      {
        for (int j = i + 1; j <= str.Length ; j++)
        {
          if (bps[j] == -1)
          {
            //Destination cell doesn't have valid backpointer yet
            //Try with the current substring
            String s = str.Substring(i, j - i);
            if (words.Contains(s))
              bps[j] = i;
          }
        }        
      }      
      //Backtrack to recovery sequence and then reverse 
      List<String> seg = new List<string>();
      for (int bp = str.Length; bps[bp] != -1 ;bp = bps[bp])      
        seg.Add(str.Substring(bps[bp], bp - bps[bp]));      
      seg.Reverse();
      return seg.ToArray();
    }

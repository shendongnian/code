    string pattern = "a";
    string source = "this is a test of a regex match";
    int maxMatches = 2;
    
    MatchCollection mc = Regex.Matches(source, pattern);
    
    if (mc.Count() > 0)
    {
      for (int i = 0; i < maxMatches; i++) 
      {
        //do something with mc[i].Index, mc[i].Length
      }
    }

       Regex r = new Regex(pattern);
       var result = r.Replace(input, new MatchEvaluator(ReplaceNewline));
    
       public string ReplaceNewline(Match m)
       {
          return m.Value.Replace("\n", "");		
       }

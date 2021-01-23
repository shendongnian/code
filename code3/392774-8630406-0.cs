    Dictionary<string, int> wordCount=new Dictionary<string,int>();
    string AppendIndex(Match m)
    {
       string matchedString = m.ToString();
       if(wordCount.Contains(matchedString))
         wordCount[matchedString]=wordCount[matchedString]+1;
       else
         wordCount.Add(matchedString, 1);
      return matchedString + "_"+ wordCount.ToString();// in the format: word_1, word_2
    }
    
    
    string inputText = "....";
    string regexText = @"";
        
       static void Main() 
       {
          string text = "....";
          string result = Regex.Replace(text, @"^\b[A-Za-z0-9_]{4,}\b:",
             new MatchEvaluator(AppendIndex));
       }

      static string[] FindQuestionObjects(string text)
      {
         System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(
            @"Which of the following can be ([^\?]+)\?",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
         System.Text.RegularExpressions.MatchCollection mc = re.Matches(text);
         string[] result = new string[mc.Count];
         for(int i = 0; i < result.Length; i++)
            result[i] = mc[i].Groups[1].Value;
         return result;
      }

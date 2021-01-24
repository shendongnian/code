      try {
 
         Console.WriteLine(Regex.Replace(words, pattern, evaluator, 
                                         RegexOptions.IgnorePatternWhitespace,
                                         TimeSpan.FromSeconds(.25)));      
      }
      catch (RegexMatchTimeoutException) {
         Console.WriteLine("Returned words:");
      }

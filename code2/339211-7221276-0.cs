      static string ExtractQuestionObject(string question)
      {
         const string pattern = "Which of the following can be ";
         if (question.StartsWith(pattern, StringComparison.CurrentCultureIgnoreCase)
             && question.EndsWith("?"))
            return question.Substring(pattern.Length, question.Length - pattern.Length - 1);
         else
            return null;
      }

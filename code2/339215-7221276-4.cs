      static string FindQuestionObject(string text)
      {
         const string pattern = "Which of the following ";
         int questionStart = text.IndexOf(pattern);
         if (questionStart >= 0)
         {
            int questionMark = text.IndexOf('?', questionStart);
            if (questionMark > questionStart)
               return text.Substring(questionStart + pattern.Length,
                      questionMark - questionStart - pattern.Length);
         }
         return null;
      }

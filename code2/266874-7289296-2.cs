    static string UppercaseFirst(string UpperCase)
    {
       if (string.IsNullOrEmpty(UpperCase))
       {
          return string.Empty;
       }
       
       return char.ToUpper(UpperCase[0]) + UpperCase.Substring(1);
    }

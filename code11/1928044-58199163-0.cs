      string test = @"٢٠١٩-٠٩-٠٣";
      
      string translated = string.Concat(test.Select(c => char.GetNumericValue(c) < 0 
         ? c.ToString()                          // Character, keep intact  
         : char.GetNumericValue(c).ToString())); // Digit! we want them be 0..9 only
      // Arabic language has right to left order, that's why pattern is "yyyy-M-d"
      DateTime result = DateTime.ParseExact(
        translated, 
       "yyyy-M-d", 
        CultureInfo.InvariantCulture, 
        DateTimeStyles.AssumeLocal);
      // English Great Britain culture
      Console.Write(result.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("en-GB")));

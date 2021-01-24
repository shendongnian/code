      string startdate = @"٢٠١٩-٠٩-٠٣";
      
      string translated = string.Concat(startdate.Select(c => char.GetNumericValue(c) < 0 
         ? c.ToString()                          // Character, keep intact  
         : char.GetNumericValue(c).ToString())); // Digit! we want them be 0..9 only
      // Arabic language has right to left order, that's why pattern is "yyyy-M-d"
      DateTime dateTime = DateTime.ParseExact(
        translated, // note, not startdate
       "yyyy-M-d", 
        CultureInfo.InvariantCulture, 
        DateTimeStyles.AssumeLocal);
      // English, Great Britain culture
      Console.Write(dateTime.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("en-GB")));

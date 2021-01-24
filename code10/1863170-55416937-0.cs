     if (!string.IsNullOrEmpty(input) &&
          input.All(c => char.IsLetter(c)) &&
          string.Equals(input, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input))) {
       // Correct Name : Not empty, Letters only, Title Case
     } 

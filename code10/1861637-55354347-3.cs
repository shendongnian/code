      Regex regex = null; 
      while (true) { 
        Console.WriteLine("Please, provide the pattern: ");
        try {
          // Try to get pattern from user
          // Trim() - let's be nice and remove leading / trailing spaces
          regex = new Regex(Console.ReadLine().Trim(), RegexOptions.CultureInvariant);
          // if pattern is syntactically valid
          break;
        }
        catch (ArgumentException e) {
          Console.WriteLine($"Pattern is invalid: {e.Message}");
        }  
      }
      // We have a valid Regex regex based on user pattern; let's use it:
      foreach (Match match in regex.Matches(line))
      {
          Console.WriteLine("match");
      } 
   

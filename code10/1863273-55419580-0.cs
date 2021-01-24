      using System.Text.RegularExpressions;
      ...
      Console.Write("Vnesite ime (prva začetnica naj bo velika, ostale male): ");
    
      // Keep looping
      while (true) {
        // Get a new user input
        //   .Normalize() - let diacritics be represent in a standard way
        //   .Trim()      - let be nice and remove leading/trailinf white spaces 
        novaDrzava.Ime = Console.ReadLine().Normalize().Trim();
    
        // If input is valid (uppercase followed zero or more lowercase) one we can stop looping
        if (Regex.IsMatch(drzava, @"^\p{Lu}\p{Ll}*$")
          break;
    
        // input is not valid: let user know it and keep askig
        Console.WriteLine ("Ponovno vnesite ime");
      }
      // From now on novaDrzava.Ime contains a valid name  

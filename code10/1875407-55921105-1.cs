     using System.Globalization;
     ...  
     public static float parseFloat(string number) {
      // float.TryParse doesn't throw exceptions but returns true or false
      if (float.TryParse(number, 
                         NumberStyles.Any, 
                         CultureInfo.InvariantCulture, 
                         out float result))
        return result;
      else {
        Console.WriteLine("Invalid floating point value.");
        // Not A Number
        return float.NaN;
      }
    } 

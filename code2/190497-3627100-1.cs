    public static string Transform(string text)
    {
      // Insert null-check here. You may also want to trim the string.
 
      var letters = text.Where(char.IsLetter).OrderBy(l => l).ToArray();
      var numbers = text.Where(char.IsNumber).OrderBy(n => n).ToArray();
    
      if (letters.Length != numbers.Length || (letters.Length + numbers.Length != text.Length))
           throw new FormatException("Text must consist only of an equal number of letters and numbers.");
      
      var zipped = letters.Zip(numbers, (l, n) => l + n);
      return string.Concat(zipped.ToArray());
    }

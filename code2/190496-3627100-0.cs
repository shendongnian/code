    public static string Transform(string text)
    {
      var letters = text.Where(char.IsLetter).OrderBy(l => l).ToArray();
      var numbers = text.Where(char.IsNumber).OrderBy(n => n).ToArray();
    
      if (letters.Length != numbers.Length || (letters.Length + numbers.Length != text.Length))
           throw new ArgumentException("Text does not match format.", "text");
      
      var zipped = letters.Zip(numbers, (l, n) => l + n);
      return string.Concat(zipped.ToArray());
    }

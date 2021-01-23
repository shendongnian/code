     string s = @"$KUH% I*$)OFNlkfn$";
     var result = s.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c));
    
        foreach (var c in result)
        {
          Console.Write(c);
        }

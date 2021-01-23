      string source = "StaCkOverFloW";
      string result = string.Concat(source.Select(c => char.IsLower(c)
        ? char.ToUpper(c) : char.IsUpper(c)
        ? char.ToLower(c) : c));
...
      // sTAcKoVERfLOw 
      Console.Write(result);

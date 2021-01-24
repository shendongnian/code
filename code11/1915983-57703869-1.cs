      var pattern = @"^([^\[]+)\[([^\]]*)\]";
      var queries = new string[]{ "Abc[123]", "Abc[xy33]", "Abc[]", "Abc[ 33 ]", "Abc" };
      foreach (var query in queries)
      {
        string beforeBrackets;
        string insideBrackets;
        var match = Regex.Match(query, pattern);
        if (match.Success)
        {
          beforeBrackets = match.Groups[1].Value;
          insideBrackets = match.Groups[2].Value.Trim();
          if (insideBrackets == "")
            insideBrackets = "0";
          else if (!int.TryParse(insideBrackets, out int i))
            insideBrackets = "incorrect value!";
        }
        else
        {
          beforeBrackets = query;
          insideBrackets = "no value";
        }
        Console.WriteLine($"Input string {query} : before brackets: {beforeBrackets}, inside brackets: {insideBrackets}");
      }
      Console.ReadKey();

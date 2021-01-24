    string input = "test1234|5678|9"
    var result1 = input.Split('|')
          .Select(y =>
              y.Any(Char.IsDigit) ? string.Join("", y.Where(x => char.IsDigit(x))) : y
            );

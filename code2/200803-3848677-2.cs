    List<String> Lst = new List<string> { "1", "2", "2.A","10.A", "2.C", "3", "3.A", "3.B","2.B","11.D" };
    Lst = Lst.Select(X => new
            {
                Number = int.Parse( Regex.Match(X, @"([0-9]*).?([a-zA-Z]*)").Groups[1].Value),
                Strings=Regex.Match(X, @"([0-9]*).?([a-zA-Z]*)").Groups[2].Value,
                OriginalString = X
            }).OrderBy(X => X.Number).ThenBy(X=>X.Strings)
            .Select(X => X.OriginalString).ToList();

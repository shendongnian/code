    var q = strings.Select(s => s.Split(new[] {'.'}, 2))
        .Select(s => new
                            {
                                Number = Convert.ToInt32(s[0]),
                                Name = s[1]
                            })
        .OrderBy(s => s.Number)
        .Select(s => string.Format("{0}.{1}", s.Number, s.Name));

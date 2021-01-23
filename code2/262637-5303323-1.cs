    var whiteSpaceRegex = new Regex(@"\s+", RegexOptions.Compiled);
    var results = lines
            .Select(line => {
                var pair = line.Split(new[] {':'}, 2);
                return new {
                    Key = whiteSpaceRegex.Replace(pair[0], string.Empty),
                    Value = whiteSpaceRegex.Replace(pair[1], string.Empty),
                };
            }).ToList();

    var results = lines
            .Select(line => {
                var pair = line.Split(new[] {':'}, 2);
                return new {
                    Key = pair[0].Trim(),
                    Value = pair[1].Trim(),
                };
            }).ToList();

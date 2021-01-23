    var parsed = File.ReadLines(filename)
                .Select(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(MyIntegerParse)
                    .ToArray())
                .ToArray();

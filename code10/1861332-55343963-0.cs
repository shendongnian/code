                var locationOutputDistinct = new List<string>
                {
                    "FRNT:2 REAR:1 ",
                    "FRNT:2 ROOF:1 ",
                    "FRNT:2 ROOF:1 REAR:1 ",
                    "FRNT:3 ",
                    "FRNT:3 REAR:1 ",
                    "FRNT:4 ",
                    "FRNT:4 REAR:1 ",
                    "FRNT:3 ROOF:1 ",
                    "FRNT:5 ",
                    "FRNT:4 ROOF:1 ",
                    "FRNT:6 ",
                    "FRNT:5 ROOF:1 ",
                    "FRNT:7 ",
                    "FRNT:6 ROOF:1 ",
                    "FRNT:8 "
                };
                var parsedData = locationOutputDistinct
                    .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(y => new KeyValuePair<string, int>(y.Substring(0, y.IndexOf(":")), int.Parse(y.Substring(y.IndexOf(":") + 1)))).OrderBy(z => z.Key).ToList())
                        .ToList();
                var groups = parsedData
                    .GroupBy(x => string.Join("^", x.Select(y => y.Key)))
                    .ToList();
                var results = groups.Select(x => x.SelectMany(y => y).GroupBy(z => z.Key).Select(z => new { Key = z.Key, Value = z.Max(a => a.Value)}).ToList()).ToList();

    static class MLCsvHelper
    {
        private class ColumnDefinition
        {
            private readonly int end;
            public string Name { get; }
            public int Start { get; }
            public int Count { get; }
            public ColumnDefinition(string name, int start, int count) =>
                (Name, Start, Count, end) = (name, start, count, start + count - 1);
            public override string ToString() =>
                $"{Name}:\"{Start}:{end}\"";
        }
        public static void Patch(string file, out string csv)
        {
            csv = Path.ChangeExtension(file, "patched.csv");
            var lines = File.ReadAllLines(file);
            var columns = lines.TakeWhile(line => line.Contains("#@"))
                .Where(i => i.Contains("col=")).Select(i =>
                {
                    var items = i.Split(new[] { '=', ':' });
                    var name = items[1];
                    var range = items.Last().Split('-');
                    var start = int.Parse(range.First());
                    var last = int.Parse(range.Last());
                    var count = last - start + 1;
                    return new ColumnDefinition(name, start, count);
                })
                .ToArray();
            var data = lines.SkipWhile(line => line.Contains("#@")).Skip(1)
                .Select(i => i.Split('\t')).ToArray();
            var res = new List<string>();
            var header = string.Join("\t", columns.Select(i => i.Name));
            res.Add(header);
            foreach (var d in data)
            {
                var values = new List<string>();
                foreach (var col in columns)
                {
                    var val = d.Skip(col.Start).Take(col.Count).ToArray();
                    var vector = string.Join("\t", val);
                    if (val.Length > 1)
                        vector = $"\"{vector}\"";
                    values.Add(vector);
                }
                var line = string.Join("\t", values);
                res.Add(line);
            }
            File.WriteAllLines(csv, res.ToArray());
        }
    }
    MLCsvHelper.Patch("zvVEYT", out var csv);

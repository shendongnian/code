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
                .Where(line => line.Contains("col=")).Select(line => GetColumn(line))
                .ToArray();
            var data = lines.SkipWhile(line => line.Contains("#@")).Skip(1)
                .Select(line => line.Split('\t')).ToArray();
            var res = new[] { string.Join("\t", columns.Select(column => column.Name)) }
                .Concat(data.Select(item => string.Join("\t", columns.Select(column => GetValue(column, item)))));
            File.WriteAllLines(csv, res.ToArray());
        }
        private static ColumnDefinition GetColumn(string line)
        {
            var items = line.Split(new[] { '=', ':' });
            var name = items[1];
            var range = items.Last().Split('-');
            var start = int.Parse(range.First());
            var last = int.Parse(range.Last());
            var count = last - start + 1;
            return new ColumnDefinition(name, start, count);
        }
        private static string GetValue(ColumnDefinition column, string[] data)
        {
            var chunk = data.Skip(column.Start).Take(column.Count);
            var value = string.Join("\t", chunk);
            if (chunk.Skip(1).Any())
                value = $"\"{value}\"";
            return value;
        }
    }
    MLCsvHelper.Patch("zvVEYT", out var csv);

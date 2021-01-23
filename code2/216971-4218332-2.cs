    File.WriteAllLines(
        "test.txt",
        File.ReadLines("test.txt")
            .Select(line => line.Split('|'))
            .Select(tokens => new
            {
                Value = int.Parse(tokens[1]),
                Text = tokens[0]
            })
            .GroupBy(li => li.Text)
            .Select(g => string.Format("{0}|{1}", g.Key, g.Sum(l => l.Value)))
            .ToArray()
    );

    File.WriteAllLines(
        "test.txt", 
        File.ReadAllLines("test.txt")
            .Select(line => new LineItem
            {
                Value = int.Parse(line.Split('|')[1]),
                Text = line.Split('|')[0]
            })
            .GroupBy(li => li.Text)
            .Select(g => string.Format("{0}|{1}", g.Key, g.Sum(l => l.Value)))
            .ToArray()
    );

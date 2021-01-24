    var duplicates = listBox1.Items.GroupBy(x => x)
                                   .Where(g => g.Count() > 1)
                                   .Select(y => new { ItemName = y.Key, Occurrences = y.Count() })
                                   .ToList();
    foreach (var duplicate in duplicates)
        Console.WriteLine($"{duplicate.ItemName}: {duplicate.Occurrences}");

    public static void OutputInColumns(List<string> items, int columnCount,
        int columnWidth, string header = null)
    {
        // If no columns or no items are specified, return
        if (columnCount == 0 || items?.Any() != true) return;
        var count = items.Count;
        // Determine how many rows we need and fill in last row with empty values if needed
        var rows = count / columnCount + (count % columnCount > 0 ? 1 : 0);
        items.AddRange(Enumerable.Range(0, 
            columnCount - count % columnCount).Select(x => string.Empty));
        // Output our column headers
        if (!string.IsNullOrEmpty(header))
            Console.WriteLine(string.Join(" ║ ",
                Enumerable.Range(0, columnCount)
                    .Select(x => header.PadRight(columnWidth, ' '))));
        // Output a divider
        if (!string.IsNullOrEmpty(header))
            Console.WriteLine(string.Join("═╬═",
                Enumerable.Range(0, columnCount)
                    .Select(x => new string('═', columnWidth))));
        // Output our row data
        for (int row = 0; row < rows; row++)
        {
            // For each row, add a line with items separated by a tab
            Console.WriteLine(string.Join(" ║ ", items
                .Skip(row * columnCount)
                .Take(columnCount)
                .Select(item => item
                    .Substring(0, Math.Min(item.Length, columnWidth))
                    .PadRight(columnWidth, ' '))));
        }
    }

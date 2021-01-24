    public static void OutputInColumns(IEnumerable<string> items, int columnCount, 
        int columnWidth, string header = null)
    {
        // If no columns or no items are specified, return
        if (columnCount == 0 || items?.Any() != true) return;
        var count = items.Count();
        // Determine how many rows we need
        var rows = count / columnCount + (count % columnCount > 0 ? 1 : 0);
        // Output our column headers
        if (!string.IsNullOrEmpty(header))
            Console.WriteLine(string.Join("\t",
                Enumerable.Range(0, columnCount)
                .Select(x => header.PadRight(columnWidth, ' '))));
        for (int row = 0; row < rows; row++)
        {
            // For each row, add a line with items separated by a tab
            Console.WriteLine(string.Join("\t", items
                .Skip(row * columnCount)
                .Take(columnCount)
                .Select(item => item
                    .Substring(0, columnWidth)
                    .PadRight(columnWidth, ' '))));
        }
    }

    private static void button1_Click(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines("testywesty.txt");
        var items = new double[lines.Length, 4];
        var delims = new[] {';', ' '};
        for (var line = 0; line < lines.Length; line++)
        {
            var parts = lines[line].Split(delims);
            var maxParts = Math.Min(parts.Length, items.GetLength(1));
            for (var part = 0; part < maxParts; part++)
            {
                if (part == 0)
                {
                    // Parse first item to a date then use ToOADate to make it a double
                    items[line, part] = DateTime.Parse(parts[part]).ToOADate();
                }
                else
                {
                    items[line, part] = double.Parse(parts[part]);
                }
            }
        }
        // Show the output
        var output = new StringBuilder();
        for (var row = 0; row < items.GetLength(0); row++)
        {
            var result = new List<string>();
            for (var col = 0; col < items.GetLength(1); col++)
            {
                result.Add(col == 0
                    ? DateTime.FromOADate(items[row, col]).ToShortDateString()
                    : items[row, col].ToString());
            }
            output.AppendLine(string.Join(", ", result));
        }
        MessageBox.Show(output.ToString(), "Results");
    }

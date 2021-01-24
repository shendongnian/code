    private void HardButton_Click(object sender, EventArgs e)
    {
        var result = File.ReadLines("h1.txt").
             Where(line => !string.IsNullOrWhitespace(line)).
             Select(line => int.Parse(line)).
             ToArray();
    }

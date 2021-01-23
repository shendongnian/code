    for (int i = 1; i < 7; i++)
    {
        // Assume the substring of ReadLine() contains "-.23455", for example
        var item = Double.Parse(reader.ReadLine(44).Substring(8 * i, 8), CultureInfo.InvariantCulture);
        richTextBox1.Text += item.ToString() + "\n";  
    }

    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        return;
    List<string> staff = new List<string>();
    List<string> other = new List<string>();
        
    foreach (var line in File.ReadLines(openFileDialog1.FileName))
    {
        line = line.ToLower();
        if (line.Contains("staff"))
        {
            staff.Add(line);
        }
        else
        {
            other.Add(line);
        }
    }
        
    relevantcount = staff.Count;
    irrelevantCount = other.Count;
        
    textBox1.Text = string.Join(","+Environment.NewLine, staff);
    textBox2.Text = string.Join("."+Environment.NewLine, other);

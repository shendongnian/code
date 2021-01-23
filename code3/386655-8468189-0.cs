    var lines = haystack.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    for(int i=0; i <lines.Length; i++)
    {
        foreach (Match m in Regex.Matches(lines[i], needle))
            richTextBox1.Text += string.Format("\nFound @ line {0}", i+1)
    }

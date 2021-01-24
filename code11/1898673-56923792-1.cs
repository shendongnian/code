    string text = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding(1252));
    string[] textLines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    int l = textLines.Length - 1;
    for (int i = l; i >= 0; i--)
    {
        string[] questions = textLines[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        int n = questions.Length;
        for (int y = 0; y < n; y++)
            textLines[i] = textLines[i] + "\n" + questions[y].Trim();
    }
    txtEditor.Text = string.Join("\n", textLines);

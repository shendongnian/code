    StringBuilder sb = new StringBuilder();
    foreach (string path in filePaths)
    {
        sb.AppendLine(path);
    }
    textBox2.Text = sb.ToString();

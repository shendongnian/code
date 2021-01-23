    private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        string text = TextBox1.SelectedText;
        var strA = Regex.Match(text, @"\w+");
        int indexA = TextBox1.SelectionStart + text.IndexOf(strA.Value);
        TextBox1.Select(indexA, strA.Value.Length);
    }

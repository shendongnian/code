    List<string> _Words;
    private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
    {
        richTextBox1.SelectionBackColor = Color.DeepPink;
        _Words.Add(richTextBox1.SelectedText);
    }

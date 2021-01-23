    private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      int characterIndex = this.textBox1.SelectionStart;
      string characterIndexSubstring = this.textBox1.Text.Substring(0, characterIndex);
      int lineNumber = characterIndexSubstring.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
      string[] lines = textBox1.Text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      string clickedOnValue = lines[lineNumber];
      MessageBox.Show(clickedOnValue);
    }

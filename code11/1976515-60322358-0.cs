    private void richTextBox1_Click(object sender, EventArgs e)
    {
        int index = richTextBox1.SelectionStart;
        int line = richTextBox1.GetLineFromCharIndex(index);
        string lineText = (richTextBox1.Lines.Length > 0) ? richTextBox1.Lines[line] : "";
        //Debug output for my own testing purposes
        Debug.WriteLine(lineText);
    }  

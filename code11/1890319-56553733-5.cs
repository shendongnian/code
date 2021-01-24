    private void Button1_Click(object sender, EventArgs e)
    {
        // Get words from textbox as an array.
        var words = textBox1.Text.Split(' ');
        // Write the words to a text file, with each item on it's own line
        System.IO.File.WriteAllLines(@"c:\test.txt", words);
    }

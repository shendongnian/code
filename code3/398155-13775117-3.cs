    private void searchButton_Click(object sender, EventArgs e)
    {
        //Select all text and bring it back to default color values so you
        //can make a new search selection
        richTextBox1.SelectAll();
        richTextBox1.SelectionColor = System.Drawing.Colors.Black;
        //Deselect all text to ready selections
        richTextBox1.DeselectAll();
        //Create a MatchList variable and initialize it to all matches
        //within the RichTextBox. Add a using statement of 
        //System.Text.RegularExpressions 
        Color evenColor = Color.Red;
        Color oddColor = Color.Blue;
        MatchCollection matches = Regex.Matches(richTextBox1.Text,  searchTextBox.Text);
        //Apply color to all matching text
        int matchCount = 0;
        foreach (Match match in matches)
        {
            richTextBox1.Select(match.Index, match.Length);
            //richTextBox1.SelectionColor = System.Drawing.Color.Red;
            richTextBox1.SelectionColor = 
                matchCount++ % 2 == 0 ? evenColor : oddColor;
        }
    }

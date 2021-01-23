    public int startAt = 0;
    private void btnGrabWordPairs_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"\b\w+\s+\w+\b"); //Start at word boundary, find one or more word chars, one or more whitespaces, one or more chars, end at word boundary
            if (startAt <= txtTest.Text.Length)
            {
                string match = regex.Match(txtArticle.Text, startAt).ToString();
                MessageBox.Show(match);
                startAt += match.Length; //update the starting position to the end of the last match
            }
         {

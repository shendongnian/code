    private void AddBtn_Click(object sender, EventArgs e)
    {
        // Make sure we can convert our number first
        int additionalScoreTotal;  // This will hold the converted value
        if (int.TryParse(scoreTotalTxt.Text, out additionalScoreTotal))
        {
            scoreCount++;
            scoreTotal += additionalScoreTotal; // If we made it past the if, this has our value
            scoreTotalTxt.Text = scoreTotal.ToString();
            scoreCountTxt.Text = scoreCount.ToString();
            int average = scoreTotal / scoreCount;
            averageTxt.Text = average.ToString();
            scoreTxt.Focus();
        }
        else
        {
            MessageBox.Show("Error: The value in 'ScoreTotal' is not a valid integer");
            // Optionally, select the problematic text so they can change it
            scoreTotalTxt.Focus();
            scoreTotalTxt.SelectAll();
        }
    }

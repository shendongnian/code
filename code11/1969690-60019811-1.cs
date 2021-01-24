    private void CheckButton_Click(object sender, EventArgs e)
    {
        string textToProcess = inputTextBox.Text;
        string processedText = PhoneToNumber(textToCheck );
        resultsLabel.Text = processedText ;
    }

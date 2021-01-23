    public string Result = string.Empty;
    
    private void secondFormCloseButton_Click(object sender, EventArgs e)
    {
        Result = secondFormTextBox.Text;
        Close();
    }

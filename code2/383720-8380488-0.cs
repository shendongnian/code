    protected void OnPasswordKeydown(object sender, KeyEventArgs e)
    {
    	bool isValid = Password.Text.Length < 6;
    	
    	ErrorText.Visible = isValid;
    	AcceptButton.Visible = isValid;
    }

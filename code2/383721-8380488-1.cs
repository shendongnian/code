    protected override void OnLoad(object sender, EventArgs e)
    {
        base.OnLoad(sender, e);
        txtPassword.KeyDown += OnPasswordKeydown;     
    }
    protected void OnPasswordKeydown(object sender, KeyEventArgs e)
    {
    	bool isValid = txtPassword.Text.Length < 6;
    	
    	ErrorText.Visible = isValid;
    	AcceptButton.Visible = isValid;
    }

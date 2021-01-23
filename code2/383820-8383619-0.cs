    bool passIsValid, userIsValid;
    
    public AuthenticationWindow()
    {
        InitializeComponent();
    
        // Creating TextChanged events which till validate input fields.
        txtUserName.TextChanged += new EventHandler(txtCheck_TextChanged);
        txtPassword.TextChanged += new EventHandler(txtCheck_TextChanged);
    }
    
    private void txtCheck_TextChanged(object sender, EventArgs e)
    {
        // Checking for empty user name field.
        if (string.IsNullOrEmpty(txtUserName.Text))
        {
            lblMessageUser.Text = "User Name field cannot be empty!";
            lblMessageUser.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            userIsValid = false;
        }
        // Making sure that user name is at least 6 characters long.
        else if (txtUserName.Text.Length < 6)
        {
            lblMessageUser.Text = "User Name field must be at least 6 characters long!";
            lblMessageUser.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            userIsValid = false;
        }
        // Checking for user name made of same repeating character.
        // Invalid example: 'aaaaaa'
        else if (!txtUserName.Text.Distinct().Skip(1).Any())
        {
            lblMessageUser.Text = "User Name cannot be made of repeating the same characters!";
            lblMessageUser.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            userIsValid = false;
        }
    	else
    	{
    		userIsValid = true;
            lblMessageUser.Text = "Password is valid.";
            lblMessageUser.ForeColor = Color.Green;
    	}
    	
        // Checking for Null or Empty string in password field.
        if (string.IsNullOrEmpty(txtPassword.Text))
        {
            lblMessagePass.Text = "Password field cannot be empty!";
            lblMessagePass.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            passIsValid = false;
        }
        // Making sure that password is at least 6 characters long.
        else if (txtPassword.Text.Length < 6)
        {
            lblMessagePass.Text = "Password field must be at least 6 characters long!";
            lblMessagePass.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            passIsValid = false;
        }
        // Checking for password made of same repeating character.
        // Invalid example: 'aaaaaa'
        else if (!txtPassword.Text.Distinct().Skip(1).Any())
        {
            lblMessagePass.Text = "Password cannot be made of repeating the same characters!";
            lblMessagePass.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            passIsValid = false;
        }
    	else
    	{
    		passIsValid = true;
            lblMessagePass.Text = "Password is valid.";
            lblMessagePass.ForeColor = Color.Green;
    	}
    
        // Making sure that user name and password are not the same.
        // Security measure.
        if (txtUserName.Text == txtPassword.Text)
        {
            lblMessageUser.Text = "User Name and Password can not be the same!";
            lblMessagePass.Text = "User Name and Password can not be the same!";
            lblMessageUser.ForeColor = Color.IndianRed;
            lblMessagePass.ForeColor = Color.IndianRed;
            btnAuthenticate.Enabled = false;
            userIsValid = false;
            passIsValid = false;
        }
    	
        // If all other checks aren't trigered; enable authentication.
    	if (passIsValid && userIsValid)
    	{
    		btnAuthenticate.Enabled = true;
    	}
    }

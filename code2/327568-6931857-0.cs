    private bool FormIsValid()
    {
        bool isValid = true;
        string strErrors = string.Empty;
        if (!(txtFirstName.Text.Length > 1) || !(txtLastName.Text.Length > 1))
        {
            strErrors = "You must enter a first and last name.";
            isValid = false;
        }
        if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".") || !(txtEmail.Text.Length > 5))
        {
            strErrors += "\nYou must enter a valid email address.";
            isValid = false;
        }
        if (!(txtUsername.Text.Length > 7) || !(pbPassword.Password.Length > 7) || !ContainsNumberAndLetter(txtUsername.Text) || !ContainsNumberAndLetter(pbPassword.Password))
        {
            strErrors += "\nYour username and password most both contain at least 8 characters and contain at least 1 letter and 1 number.";
            isValid = false;
        }
        if (isValid == false)
        {
            MessageBox.Show(strErrors);
        }
        return isValid;
    }

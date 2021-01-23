    if (string.IsNullOrEmpty(txtHost.Text))
    {
        errorProvider.SetError(txtHost, "Please enter the host address"); 
        isValid = false;
    }

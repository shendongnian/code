    try
    {
        auth.Login(txtUsername.Text, txtPassword.Text);
    }
    catch (ArgumentException e)
    {
        //Handle Exception here
        MessageBox.Show(e.ToString(), "EMail invalid");
    }

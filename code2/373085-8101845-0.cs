    if(chkRememberMe.Checked)
    {
    Properties.Settings.Default.Username = txtUsername.Text;
    Properties.Settings.Default.Password = txtPassword.Text;
    Properties.Settings.Default.Save();
    }

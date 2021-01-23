    private void btnWelcome_Click(object sender, EventArgs e)
    {
        TestService.TestService ws = new TestService.TestService(); //Create a web service
        ws.SetUserName(txtUserName.Text); 
        string sWelcome = ws.WelcomeMsg();
        System.Diagnostics.Debug.WriteLine(sWelcome); 
    }

    protected void BtnLogin_Clicked(object s, EventArgs e)
    {
        string errMess;
        if(!Behind.TryLogin(out errMess)
           lblMessage.Text = errMess;
    }

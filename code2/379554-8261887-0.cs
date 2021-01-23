    protected void BtnLogin_Clicked(object s, EventArgs e)
    {
        string errMess;
        var o = new Behind();
        if(!o.TryLogin(out errMess)
           lblMessage.Text = errMess;
    }

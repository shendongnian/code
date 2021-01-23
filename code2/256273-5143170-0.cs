    var frame = ie.Frame("loginframe");
    
    frame.TextField(Find.ById("lgnId1")).Value = txtUsername.Text;
    frame.TextField(Find.ById("pwdId1")).Value = txtPassword.Text;
    frame.Button(Find.ById("submitID")).Click();

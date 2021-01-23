    protected void buttonClick(object sender, EventArgs e)
    {
       EasyToCallMethod();
    }
    
    public void EasyToCallMethod()
    {
    string currUser = User.Identity.Name.ToString().Trim().Substring(User.Identity.Name.ToString().Trim().IndexOf("\\") + 1);
    //...rest of code
    }

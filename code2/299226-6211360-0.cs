    using (var ie = new IE(loginUrl)) 
    {
        if (ie.TextField("username").Exists 
           && ie.TextField("password").Exists)
        {
            ie.TextField("username").Value = "username";
            ie.TextField("password").Value = "password";
            ie.Button(Find.ByName("submit")).Click();
        }
    }

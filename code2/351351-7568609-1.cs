    using(var browser = new IE("http://134.554.444.55/asdfgfghh/"))
    {
        var page = browser.Page<MyClass>();
        page.NameField.TypeText("name field");
        page.PasswordField.TypeText("password field");
        page.LoginButton.Click();
    }

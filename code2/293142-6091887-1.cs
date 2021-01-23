    private void Logon(string username, string password)
    {
        HtmlElement usernameField = HtmlPage.Document.GetElementById("username");
        usernameField.SetAttribute("value", username);
        HtmlElement passwordField = HtmlPage.Document.GetElementById("password");
        passwordField.SetAttribute("value", password);
        HtmlPage.Document.Submit();
    }

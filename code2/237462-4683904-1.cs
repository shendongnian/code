    public static bool IsValidLogin(string user, string password)
    {
        XDocument doc = XDocument.Load("Login.xml");
        return doc.Descendants("id")
                  .Where(id => id.Attribute("userName").Value == user 
                         && id.Attribute("passWord").Value == password)
                  .Any();
    }

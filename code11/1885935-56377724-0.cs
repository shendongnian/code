    // Create a SecureString
    SecureString password = new SecureString();
    foreach (char c in ConfigurationManager.AppSettings["xyz"].ToString())
    {
        password.AppendChar(c);
    }
    // Use password
    this.SomeMethod(password);
    // Remove password
    password.Dispose();

    var user = "username";
    var pass = new System.Security.SecureString();
    foreach (char c in "password")
    {
        pass.AppendChar(c);
    }
    var cred = new System.Management.Automation.PSCredential(user, pass);

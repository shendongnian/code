    public static void SaveUser(UserPrincipal user, string textFile)
    {
        DirectoryEntry de = (user.GetUnderlyingObject() as DirectoryEntry);
        string thisUser = $"{user.Name},{de.Properties["department"].Value},{de.Properties["extensionAttribute1"].Value},{de.Properties["title"].Value},{de.Properties["manager"].Value.ToString().Replace(",","|")}";
        File.AppendAllLines(textFile, new string[] { thisUser }); // Append a new line with this user.
    }
and look up and save the user in main method like this,
**Usage**
Assemblies you will need for this
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System;
    using System.IO;
and usage will be like this,
    string txt_userName = "userId";
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "domainName", "userName", "Password");
    // if you are running this script from a system joined to this domain, and logged in with a domain user, simply use
    // PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    UserPrincipal user = (UserPrincipal)Principal.FindByIdentity(ctx, IdentityType.Name, txt_userName);
    if (user != null)
    {
        string saveToFile = @"C:\Users\etaarratia\Documents\prueba\nombre.txt";
        SaveUser(user, saveToFile);
    }

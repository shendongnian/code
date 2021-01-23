    // you need to supply these parameters:
    string domainName = "domain";
    string computerName = "computer";
    string userName = "name";
    string password = "password";
    var machineDirectory = new DirectoryEntry(@"WinNT://" + domainName + @"/" + computerName + ",computer");
    var userEntry = machineDirectory.Children.Add(userName, "user");
    userEntry.Invoke("SetPassword", password);
    userEntry.CommitChanges();

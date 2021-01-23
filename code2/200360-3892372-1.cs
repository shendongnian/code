    DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
    DirectoryEntry HostedUser = AD.Children.Find(hostedUserName, "user");
    
    string password = new HostedGuiAddMachines().CreateRandomPassword(8);
    HostedUser.Invoke("SetPassword", new object[] { password });
    HostedUser.Close();
    AD.Close();

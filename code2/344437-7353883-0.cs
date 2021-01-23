    //Move an object from one ou to another
    DirectoryEntry eLocation = new DirectoryEntry("LDAP://" + objectLocation);
    DirectoryEntry nLocation = new DirectoryEntry("LDAP://" + newLocation);
    string newName = eLocation.Name;
    eLocation.MoveTo(nLocation, newName);
    nLocation.Close();
    eLocation.Close();
    //Modify an attribute of a user object
    DirectoryEntry user = new DirectoryEntry(userDn);
    int val = (int)user.Properties["userAccountControl"].Value;
    user.Properties["userAccountControl"].Value = val & ~0x2; 
    user.CommitChanges();
    user.Close();

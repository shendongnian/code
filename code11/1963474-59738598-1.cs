        try
        {
            DirectoryEntry ent = new DirectoryEntry(bindString);
            ent.AuthenticationType = AuthenticationTypes.Secure;
            ent.AuthenticationType = AuthenticationTypes.Sealing;
            ent.AuthenticationType = AuthenticationTypes.Delegation;
            ent.Username = "test123@test.com";
            ent.Password = "test123";
            ent.Properties["member"].Add(newMember);
            ent.CommitChanges();
        } 
 

       using System.DirectoryServices
      private DeleteUserFromActiveDirectory(DataRow in_Gebruiker)
      {
              DirectoryEntry AD = new DirectoryEntry(strPathActiveDirectory ,
                  strUsername, strPassword)
	
              DirectoryEntry NewUser = 
                  AD.Children.Find("CN=TheUserName", "User");
             AD.Children.Remove(NewUser);
             AD.CommitChanges();
             AD.Close();
      }

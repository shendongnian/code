    public static void ChangePassword(string userName, string oldPassword, string newPassword)
    {
            string path = "LDAP://CN=" + userName + ",CN=Users,DC=demo,DC=domain,DC=com";
            //Instantiate a new DirectoryEntry using an administrator uid/pwd
            //In real life, you'd store the admin uid/pwd  elsewhere
            DirectoryEntry directoryEntry = new DirectoryEntry(path, "administrator", "password");
            try
            {
               directoryEntry.Invoke("ChangePassword", new object[]{oldPassword, newPassword});
            }
            catch (Exception ex)  //TODO: catch a specific exception ! :)
            {
               Console.WriteLine(ex.Message);
            }
            Console.WriteLine("success");
    }

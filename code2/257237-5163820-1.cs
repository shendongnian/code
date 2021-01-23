    using (var context = new PrincipalContext(ContextType.Domain, "yourdomain.com"))
    {
        using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
        {
            foreach (var result in searcher.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                Console.WriteLine();
            }
        }
    }
    Console.ReadLine();

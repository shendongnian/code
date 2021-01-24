    static void Main(string[] args)
        {
            ActiveDirectoryClient directoryClient;
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(new Uri("https://graph.windows.net/<yourtenantGUID>"),
                async () => await GetTokenForApplication());
            var directoryRoles =  activeDirectoryClient.DirectoryRoles.ExecuteAsync().GetAwaiter().GetResult();
            
            foreach (var role in directoryRoles.CurrentPage)
            {
                int memberCount = 0;
                Console.WriteLine(role.DisplayName);
                var members = activeDirectoryClient.DirectoryRoles[role.ObjectId].Members.ExecuteAsync().GetAwaiter().GetResult();
                foreach (var member in members.CurrentPage)
                {
                    // Special check, to avoid getting Service Principals in count
                    if (member.ObjectType.Equals("User"))
                    {
                        Console.WriteLine(member.ObjectId);
                        memberCount++;
                    }
                }           
                if (members.MorePagesAvailable)
                {
                    //do something about it..
                }
                Console.WriteLine("Members count = {0}", memberCount);
            }
            if(directoryRoles.MorePagesAvailable)
            {
                // do something about it..
            }
            Console.ReadLine();           
        }

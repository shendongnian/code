            var iis = new DirectoryEntry("IIS://" + Environment.MachineName + "/w3svc");
            foreach (DirectoryEntry site in iis.Children)
            {
                if (site.SchemaClassName.ToLower() == "iiswebserver")
                {
                    Console.WriteLine("Name: " + site.Name);
                    Console.WriteLine("State: " + site.Properties["ServerState"].Value);
                }
            }

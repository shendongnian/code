           using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
           {
                runspace.Open();
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    string[] members = new string[] { "testuser1@somecompany.com", "testuser2@somecompany.com" };
                    Collection<PSObject> results = ps
                        .AddCommand("Add-DistributionGroupMember")
                        .AddParameter("Identity", "test")
                        .Invoke(members);
                }
            }

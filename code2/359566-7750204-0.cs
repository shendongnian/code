                using (PowerShell ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    var members = new[]
                                      {
                                          "testuser1@somecompany.com",
                                          "testuser2@somecompany.com",
                                      };
                    var command1 = new Command("write-output");
                    command1.Parameters.Add("InputObject", members);
                    ps.Commands.AddCommand(command1);
                    foreach (PSObject output in ps.Invoke())
                    {
                        ps.Commands.Clear();
                        var command2 = new Command("Add-DistributionGroupMember");
                        ps.Commands.AddCommand(command2);
                        ps.Commands.AddParameter("Name", output);
                        ps.Commands.AddParameter("Identity", "test");
                        foreach (PSObject output2 in ps.Invoke())
                        {
                            Console.WriteLine(output2);
                        }
                    }
                }

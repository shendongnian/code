    DirectoryEntry entry = new DirectoryEntry("LDAP://" + selectedDomain);
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                mySearcher.Filter = ("(objectClass=organizationalUnit)");
                mySearcher.SizeLimit = int.MaxValue;
                mySearcher.PageSize = int.MaxValue;
                foreach (SearchResult temp in mySearcher.FindAll())
                {
                    Global.logger.Debug("OU = " + temp.Properties["name"][0].ToString());
                    DirectoryEntry ou = temp.GetDirectoryEntry();
                    DirectorySearcher mySearcher1 = new DirectorySearcher(ou);
                    mySearcher1.Filter = ("(objectClass=computer)");
                    mySearcher1.SizeLimit = int.MaxValue;
                    mySearcher1.PageSize = int.MaxValue;
                    if (temp.Properties["name"][0].ToString() == selectedOU)
                    {
                        foreach (SearchResult resEnt in mySearcher1.FindAll())
                        {
                            //"CN=SGSVG007DC"
                            string ComputerName = resEnt.GetDirectoryEntry().Name;
                            Global.logger.Debug("ComputerName = " + resEnt.Properties["name"][0].ToString());
                            if (ComputerName.StartsWith("CN="))
                                ComputerName = ComputerName.Remove(0, "CN=".Length);
                            compList.Add(ComputerName);
                        }
                    }
                    mySearcher1.Dispose();
                    ou.Dispose();
                }
                mySearcher.Dispose();
                entry.Dispose();

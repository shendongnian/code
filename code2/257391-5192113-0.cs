    using (var p4 = new P4Connection())
                {
                    p4.Connect();
                    var longName = WindowsIdentity.GetCurrent().Name;
                    var shortname = longName.Substring(longName.IndexOf("\\") + 1);
                    var records = p4.Run("clients", "-u", shortname);
    
                    cmbBoxPerforceWorkspaceLocation.Items.Clear();
    
                    foreach (P4Record record in records.Records)
                    {
                        cmbBoxPerforceWorkspaceLocation.Items.Add(record["client"]);
                    }
                }

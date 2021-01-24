     string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                          DirectorySecurity ds = Directory.GetAccessControl(folder);
                          MessageBox.Show(userName);
                          FileSystemAccessRule fsa = new FileSystemAccessRule(userName, FileSystemRights.Read, AccessControlType.Allow);
                          ds.AddAccessRule(fsa);
                          Directory.SetAccessControl(folder, ds);
                          MessageBox.Show("Permissions Removed ");
                      }
                      catch (Exception ex)
                      { MessageBox.Show(ex.Message); }

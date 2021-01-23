        public void RenameRemotePC(String oldName, String newName, String domain, NetworkCredential accountWithPermissions)
        {
            var remoteControlObject = new ManagementPath
                                          {
                                              ClassName = "Win32_ComputerSystem",
                                              Server = oldName,
                                              Path =
                                                  oldName + "\\root\\cimv2:Win32_ComputerSystem.Name='" + oldName + "'",
                                              NamespacePath = "\\\\" + oldName + "\\root\\cimv2"
                                          };
            var conn = new ConnectionOptions
                                         {
                                             Authentication = AuthenticationLevel.PacketPrivacy,
                                             Username = oldName + "\\" + accountWithPermissions.UserName,
                                             Password = accountWithPermissions.Password
                                         };
            var remoteScope = new ManagementScope(remoteControlObject, conn);
            var remoteSystem = new ManagementObject(remoteScope, remoteControlObject, null);
            
            ManagementBaseObject newRemoteSystemName = remoteSystem.GetMethodParameters("Rename");
            var methodOptions = new InvokeMethodOptions();
            newRemoteSystemName.SetPropertyValue("Name", newName);
            newRemoteSystemName.SetPropertyValue("UserName", accountWithPermissions.UserName);
            newRemoteSystemName.SetPropertyValue("Password", accountWithPermissions.Password);
            methodOptions.Timeout = new TimeSpan(0, 10, 0);
            ManagementBaseObject outParams = remoteSystem.InvokeMethod("Rename", newRemoteSystemName, null);
        }

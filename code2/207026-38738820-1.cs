    string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
    
     string office = string.Empty;
        using (var context = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["DOMAIN"].ToString()))
        {
            using (var userPrincipal = new UserPrincipal(context))
            {
                userPrincipal.SamAccountName = Username;
                using (PrincipalSearcher search = new PrincipalSearcher(userPrincipal))
                {
                    UserPrincipal result = (UserPrincipal)search.FindOne();
                    DirectoryEntry directoryEntry = result.GetUnderlyingObject() as DirectoryEntry;
                    if (directoryEntry.Properties["physicalDeliveryOfficeName"].Count > 0
                            && directoryEntry.Properties["physicalDeliveryOfficeName"][0] != null
                            && !string.IsNullOrWhiteSpace(directoryEntry.Properties["physicalDeliveryOfficeName"][0].ToString()))
                    {
                        office = directoryEntry.Properties["physicalDeliveryOfficeName"][0].ToString();
                    }
                }
            }
        }

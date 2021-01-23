     public static void CheckAceInformation(string FileName,string LoginName)
            {
                string FileSystemRightsValue = "";
                FileSecurity security = File.GetAccessControl(FileName);
    
                AuthorizationRuleCollection acl = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
    
                foreach(FileSystemAccessRule ace in acl)
                {
                    if(ace.IdentityReference.Value == LoginName)
                    {
                        FileSystemRightsValue = ace.FileSystemRights.ToString();
                        Console.WriteLine(LoginName +  "  your permission value is" + FileSystemRightsValue)
     
                        return;
                    }
                }
                Console.WriteLine(LoginName + "your not permission in this folder");
               
            }

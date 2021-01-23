     public static void checkAceInformation(string fileName,string loginName)
            {
                string fileSystemRightsValue = "";
                FileSecurity security = File.GetAccessControl(FileName);
    
                AuthorizationRuleCollection acl = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
    
                foreach(FileSystemAccessRule ace in acl)
                {
                    if(ace.IdentityReference.Value == LoginName)
                    {
                        fileSystemRightsValue = ace.FileSystemRights.ToString();
                        Console.WriteLine(LoginName +  "  your permission value is" + fileSystemRightsValue)
     
                        return;
                    }
                }
                Console.WriteLine(LoginName + "your not permission in this folder");
               
            }

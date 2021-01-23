    private static void WriteAcl ( string filename ) 
            { 
                //Set security for EveryOne Group
                SecurityIdentifier sid =new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                IdentityReference userIdentity =sid.Translate (typeof(NTAccount));           
    
                var AccessRule_AllowEveryOne = new FileSystemAccessRule ( userIdentity, FileSystemRights.FullControl, AccessControlType.Allow );
                var securityDescriptor = new FileSecurity ();
                securityDescriptor.SetAccessRule ( AccessRule_AllowEveryOne );            
                File.SetAccessControl ( filename, securityDescriptor ); 
            } 

            var pc = new PrincipalContext(ContextType.Domain); 
            
            var user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName,"DOMAIN\\USER");
            
            var g = System.DirectoryServices.AccountManagement.GroupPrincipal.FindByIdentity(pc, IdentityType.DistinguishedName, "Everyone");
            var check = user.IsMemberOf(g);

        private static readonly string DomainName = "domaincontrollercomputer.domain.com";
        private static readonly string DomainContainer = "DC=DOMAIN,DC=COM";
        private static readonly string ADGroupName = "AD Group Name";
        private List<string> GroupName {get;set;}
          
        private void populateGroups()
        {
            using (var ctx = new PrincipalContext(ContextType.Domain, DomainName, DomainContainer))
            {
                using (var grp = GroupPrincipal.FindByIdentity(ctx, ADGroupName))
                {
                    GroupName = new List<string>();
                    foreach (var member in grp.GetMembers())
                    {
                        GroupName.Add(member.SamAccountName);
                    }
                }
            }
        }

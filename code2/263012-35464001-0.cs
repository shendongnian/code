    public static class AccountManagementExtensions
    {
        public static bool IsNestedMemberOf(this Principal principal, GroupPrincipal group)
        {
            // LDAP Query for memberOf Nested 
            var filter = String.Format("(&(sAMAccountName={0})(memberOf:1.2.840.113556.1.4.1941:={1}))",
                    principal.SamAccountName,
                    group.DistinguishedName
                );
            var searcher = new DirectorySearcher(filter);
            var result = searcher.FindOne();
            return result != null;
        }
    }

    private void DoWorkWithUserGroups(string domain, string user)
        {
            var groupType = "tokenGroupsGlobalAndUniversal"; // use tokenGroups for only security groups
            using (var userContext = new PrincipalContext(ContextType.Domain, domain))
            {
                using (var identity = UserPrincipal.FindByIdentity(userContext, IdentityType.SamAccountName, user))
                {
                    if (identity == null)
                        return;
                    var userEntry = identity.GetUnderlyingObject() as DirectoryEntry;
                    userEntry.RefreshCache(new[] { groupType });
                    var sids = from byte[] sid in userEntry.Properties[groupType]
                               select new SecurityIdentifier(sid, 0);
                    foreach (var sid in sids)
                    {
                        using(var groupIdentity = GroupPrincipal.FindByIdentity(userContext, IdentityType.Sid, sid.ToString()))
                        {
                            if(groupIdentity == null)
                                continue; // this group is not in the domain, probably from sidhistory
                            // extract the info you want from the group
                        }
                    }
                }
            }
        }

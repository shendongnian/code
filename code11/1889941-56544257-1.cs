    public static IEnumerable<string> GetGroupMemberList(DirectoryEntry group, bool recursive = false) {
        var members = new List<string>();
    
        group.RefreshCache(new[] { "member" });
    
        while (true) {
            var memberDns = group.Properties["member"];
            foreach (string member in memberDns) {
                using (var memberDe = new DirectoryEntry($"LDAP://{member.Replace("/", "\\/")}")) {
                    memberDe.RefreshCache(new[] { "objectClass", "msDS-PrincipalName", "cn" });
    
                    if (recursive && memberDe.Properties["objectClass"].Contains("group")) {
                        members.AddRange(GetGroupMemberList(memberDe, true));
                    } else {
                        var username = memberDe.Properties["msDS-PrincipalName"].Value.ToString();
                        if (!string.IsNullOrEmpty(username)) {
                            members.Add(username);
                        }
                    }
                }
            }
    
            if (memberDns.Count == 0) break;
    
            try {
                group.RefreshCache(new[] {$"member;range={members.Count}-*"});
            } catch (COMException e) {
                if (e.ErrorCode == unchecked((int) 0x80072020)) { //no more results
                    break;
                }
                throw;
            }
        }
        return members;
    }

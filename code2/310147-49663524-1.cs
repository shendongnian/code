    private static List<string> GetGroupMemberList(DirectoryEntry group, bool recurse = false) {
        var members = new List<string>();
        group.RefreshCache(new[] { "member" });
        while (true) {
            var memberDns = group.Properties["member"];
            foreach (var member in memberDns) {
                var memberDe = new DirectoryEntry($"LDAP://{member}");
                memberDe.RefreshCache(new[] { "objectClass", "sAMAccountName" });
                if (recurse && memberDe.Properties["objectClass"].Contains("group")) {
                    members.AddRange(GetGroupMemberList(memberDe, true));
                } else {
                    var username = memberDe.Properties["sAMAccountName"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(username)) { //It will be null if this is a Foreign Security Principal
                        members.Add(username);
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

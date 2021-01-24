        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (WindowsIdentity)principal.Identity;
            Guid userGuid;
            SecurityIdentifier sid = identity.User;
            using (DirectoryEntry userDirectoryEntry = new DirectoryEntry("LDAP://<SID=" + sid.Value + ">"))
            {
                userGuid = userDirectoryEntry.Guid;
            }
            UserAccount user = null;
            if (userGuid != Guid.Empty)
                user = await db.UserAccounts.Where(x => x.GUID == userGuid).SingleOrDefaultAsync();
            if (user == null)
                return principal;
            if (user.Historic)
                return principal;
            var claims = new List<Claim>();
            foreach (var role in user?.UserAccountGroups)
            {
                claims.Add(new Claim(ClaimTypes.GroupSid, role.Group.Name));
            };
            identity.AddClaims(claims);
            return principal;
        }

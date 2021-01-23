	internal const string UserNameSearchFilter = "(&(objectCategory=user)(objectClass=user)(|(userPrincipalName={0})(samAccountName={0})))";
	internal const string MembershipFilter = "(&(objectCategory=group)(objectClass=group)(cn=MyGroup)(member:1.2.840.113556.1.4.1941:={0}))";
	using (var de = new DirectoryEntry(AppSettings.LDAPRootContainer, AppSettings.AdminUser, AppSettings.AdminPassword, AuthenticationTypes.FastBind))
	using (var ds = new DirectorySearcher(de) { Filter = string.Format(UserNameSearchFilter, username) })
	{
		ds.PropertiesToLoad.AddRange(new[] { "dn" });
		var user = ds.FindOne();
		if (user != null)
			using (var gds = new DirectorySearcher(de) { PropertyNamesOnly = true, Filter = string.Format(MembershipFilter, user.Properties["dn"][0] as string) })
			{
				 gds.PropertiesToLoad.AddRange(new[] { "objectGuid" });
				 return gds.FindOne() != null;
			}
	}

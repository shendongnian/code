    public override string[] GetRolesForUser(string username)
        {
        var allRoles = new List<string>();
        var root = new DirectoryEntry(WebConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString,
                                        ConnectionUsername,
                                        ConnectionPassword);
        var searcher = new DirectorySearcher(root,
                                            string.Format(CultureInfo.InvariantCulture, "(&(objectClass=user)({0}={1}))",
                                                                                        AttributeMapUsername,
                                                                                        username));
        searcher.PropertiesToLoad.Add("memberOf");
        SearchResult result = searcher.FindOne();
        if (result != null && !string.IsNullOrEmpty(result.Path))
        {
            DirectoryEntry user = result.GetDirectoryEntry();
            PropertyValueCollection groups = user.Properties["memberOf"];
            foreach (string path in groups)
            {
                string[] parts = path.Split(',');
                if (parts.Length > 0)
                {
                    foreach (string part in parts)
                    {
                        string[] p = part.Split('=');
                        if (p[0].Equals("cn", StringComparison.OrdinalIgnoreCase))
                        {
                            allRoles.Add(p[1]);
                        }
                    }
                }
            }
        }
        return allRoles.ToArray();
    }

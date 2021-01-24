    public bool CheckUserInGroup(string group)
        {
            string serverName = ConfigurationManager.AppSettings["ADServer"];
            string userName = ConfigurationManager.AppSettings["ADUserName"];
            string password = ConfigurationManager.AppSettings["ADPassword"];
            bool result = false;
            SecureString securePwd = null;
            if (password != null)
            {
                securePwd = new SecureString();
                foreach (char chr in password.ToCharArray())
                {
                    securePwd.AppendChar(chr);
                }
            }
            try
            {  
                ActiveDirectory adConnectGroup = new ActiveDirectory(serverName, userName, securePwd);
                SearchResultEntry groupResult = adConnectGroup.GetEntryByCommonName(group);
                Group grp = new Group(adConnectGroup, groupResult);
                SecurityPrincipal userPrincipal = grp.Members.Find(sp => sp.SAMAccountName.ToLower() == User.Identity.Name.ToLower());
                if (userPrincipal != null)
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

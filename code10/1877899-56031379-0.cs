        public static string GetEmailAddressFromActiveDirectoryUserName(string adUserName)
        {
            string email = string.Empty;
            if (!string.IsNullOrEmpty(adUserName))
            {
                using (var pctx = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, adUserName))
                    {
                        return !string.IsNullOrEmpty(up?.EmailAddress) ? up.EmailAddress : string.Empty;
                    }
                }
            }
            return email;
        }

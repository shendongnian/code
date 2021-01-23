        public bool PasswordRequiresChanged(string userName)
        {
            DirectoryEntry user = GetUser(userName); //A directory entry pointing to the user
            Int64 pls;
            int uac;
            if (user != null && user.Properties["pwdLastSet"] != null && user.Properties["pwdLastSet"].Value != null)
            {
                pls = ConvertADSLargeIntegerToInt64(user.Properties["pwdLastSet"].Value);           
            }
            else
            {
                throw new Exception("Could not determine if password needs reset");
            }
            if (user != null && user.Properties["UserAccountControl"] != null && user.Properties["UserAccountControl"].Value != null)
            {
                uac = (int)user.Properties["UserAccountControl"].Value;
            }
            else
            {
                throw new Exception("Could not determine if password needs reset");
            }
            return (pls == 0) && ((uac & 0x00010000) == 0) ? true : false;
        }

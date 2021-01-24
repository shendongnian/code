 public DirectoryEntry QueryAD(string UserName)
        {
            try
            {
                DirectorySearcher ds = new DirectorySearcher
                {
                    SearchRoot = new DirectoryEntry(),
                    //start searching from local domain
                    Filter = "(&" +
                    "(objectClass=user)" +
                    "(name=" + UserName + "))" // This is Username
                };
                // start searching
                return ds.FindOne().GetDirectoryEntry();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("error occured while querying AD");
            }
        }
**Method to Check if Account is Active**
        private bool IsActive(DirectoryEntry de)
        {
            if (de.NativeGuid == null) return false;
            int flags = (int)de.Properties["userAccountControl"].Value;
            return !Convert.ToBoolean(flags & 0x0002);
        }
**Method to Save the User to your DB**
        public void SaveUser(SearchRolesViewModel objSearchRolesViewModel, string userID)
        {
            DirectoryEntry userEntry = QueryAD(objSearchRolesViewModel.User_Id);
            if (userEntry == null) 
            {
               //Handle error where No User was Found.
               throw new ApplicationException("User Not Found");
            }
            USERACCOUNT objUserAccount = new USERACCOUNT
            {
                HPID = Convert.ToInt32(objSearchRolesViewModel.NewUserHealthPlans),
                DOMAIN = "Aeth",
                NTUSERID = objSearchRolesViewModel.User_Id,
                ROLEID = Convert.ToInt32(objSearchRolesViewModel.UserRole),
                FIRSTNAME = userEntry.Properties["givenname"].Value.ToString(), 
                LASTNAME = userEntry.Properties["sn"].Value.ToString(),
                EMAIL = userEntry.Properties["mail"].Value.ToString(),
                ACTIVE = IsActive(userEntry),
                DEFAULTPLANID = Convert.ToInt32(objSearchRolesViewModel.NewUserPrimaryHealthPlan),
                CREATEID = userID,
                CREATEDATE = DateTime.Now,
                UPDATEID = userID,
                UPDATEDATE = DateTime.Now
            };
            _context.USERACCOUNTs.Add(objUserAccount);
            _context.SaveChanges();
        }

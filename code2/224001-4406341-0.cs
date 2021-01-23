        [WebMethod]
        public void CreateUser(string username)
        {
            SPWeb web = new SPSite(this.ExtranetSite).OpenWeb();
            web.AllUsers.Add(this.MembershipProvider + ":" + username, username, username, "");
            web.EnsureUser(this.MembershipProvider + ":" + username);
        }
        [WebMethod]
        public void DeleteUser(string username)
        {
            SPWeb web = new SPSite(this.ExtranetSite).OpenWeb();
            web.SiteUsers.Remove(this.MembershipProvider + ":" + username);
            web.Update();
        }

    public IQueryable<Aspnet_User> GetBannedUsers()
            {
                return db.Aspnet_Memberships
                         .Where(x => x.IsApproved == false)
                         .OrderByDescening(x => x.BannedDate) //adjust property here
                         .Select(x => x.Aspnet_User);
            }

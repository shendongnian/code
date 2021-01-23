    public class AuthenticationService : AuthenticationBase<User>
    {
        protected override User GetAuthenticatedUser(IPrincipal principal)
        {
            return base.GetAuthenticatedUser(principal).WithProfile();
        }
        [Invoke]
        public void SaveMyUser(User user)
        {
            if (user.UserId == Guid.Empty)
            {
                ClientLogger.Error("SaveMyUser failed because the UserId is invalid");
                return;                
            }
            using (var db = new Pharma360Model())
            {
                var userProfile = db.UserProfiles.Single(p => p.EpothecaryUserId == user.EpothecaryUserId);
                userProfile.SearchGroups = (int)user.SearchGroups;
                userProfile.SearchHistory = user.SearchHistoryString;
                userProfile.SearchRowsReturnedPerGroup = user.SearchRowsReturnedPerGroup;
                db.SaveChanges();
            }
        }

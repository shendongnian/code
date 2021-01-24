    public class UserPermissions : ITenancyUserPermissions, IBlah1Permissions, IBlah2Permissions
    {
        public bool CanCreateTenancy(string userId)
        {
            return CanBlah1 && CanBlah2;
        }
        public bool CanBlah1(string userID)
        {
            return _authService.Can("Blah1", userID);            
        }
        public bool CanBlah2(string userID)
        {
            return _authService.Can("Blah2", userID);
        }
    }

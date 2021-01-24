    private static List<UserViewModel> _allBCCUsers = null;
    public static List<UserViewModel> AllBCCUsers
    {
        get
        {
            if (_allBCCUsers == null)
            {
                eSTIPContext ctx = new eSTIPContext();
    			_allBCCUsers = (from u in ctx.BBCRecipient select new UserViewModel(new User() { Email = u.Email })).ToList();
    
            }
            return _allBCCUsers;
        }
    }

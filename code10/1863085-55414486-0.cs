       private readonly UserManager<IdentityUser> _userManager;
        public SweetController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityUser> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

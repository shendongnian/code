    public sealed class AspNetUserContext : IUserContext {
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor accessor;
        private readonly LazyAsync<User> currentUser;
    
        public AspNetUserContext(IHttpContextAccessor accessor, UserManager<User> userManager) {
            this.accessor = accessor;
    
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
    
            this.userManager = userManager;
            currentUser = new LazyAsync<User>(() => this.userManager.FindByIdAsync(Id.ToString()));
        }
    
        public string Name => accessor.HttpContext.User?.Identity?.Name;
        public int Id => accessor.CurrentUserId();
    
        public Task<User> GetCurrentUser() {
            return currentUser.Value;
        }
    }

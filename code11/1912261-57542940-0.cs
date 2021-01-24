    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserDbContext _userDbContext;
    
        private Guid _tenantId;
    
        public TenantProvider(UserDbContext userDbContext,
                              IHttpContextAccessor httpContextAccessor)
        {
            _userDbContext = userDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
    
        private void SetTenantId()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                // Whatever you would like to return if there is no request (eg. on startup of app).
                _tenantId = new Guid();
                return;
            }
    
            _tenantId = _userDbContext.Users.FirstOrDefault(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name)?.TenantId;
            return;
        }
    
        public Guid GetTenantId()
        {
            SetTenantId();
            return _tenantId;
        }

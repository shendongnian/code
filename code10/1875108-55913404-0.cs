        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            private HttpContext _httpContext;
            public string CurrentUser => _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                IHttpContextAccessor httpContextAccessor)
                : base(options)
            {
                _httpContext = httpContextAccessor.HttpContext;
            }        
        }

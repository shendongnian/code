     public class ProfileService : IProfileService
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IServiceCollection _services;
            private readonly ApplicationDbContext _context;
            private CalcAllowedPermissions _calcAllowedPermissions;
    
            public ProfileService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
            {
                _services = new ServiceCollection();
                var sp = _services.BuildServiceProvider();
                _userManager = userManager;
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _calcAllowedPermissions = new CalcAllowedPermissions(_context);
            }
        **//This method is called whenever claims about the user are requested (e.g. during token creation or via the userinfo endpoint)**
            public async Task GetProfileDataAsync(ProfileDataRequestContext context)
            {
                var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));
    
                var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
    
                var user = await _userManager.FindByIdAsync(subjectId);
                if (user == null)
                    throw new ArgumentException("Invalid subject identifier");
    
                var claims = GetClaimsFromUser(user,subject);
                context.IssuedClaims = claims.Result.ToList();
            }
    
            public async Task IsActiveAsync(IsActiveContext context)
            {
                var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));
    
                var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
                var user = await _userManager.FindByIdAsync(subjectId);
    
                context.IsActive = false;
    
                if (user != null)
                {
                    if (_userManager.SupportsUserSecurityStamp)
                    {
                        var security_stamp = subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault();
                        if (security_stamp != null)
                        {
                            var db_security_stamp = await _userManager.GetSecurityStampAsync(user);
                            if (db_security_stamp != security_stamp)
                                return;
                        }
                    }
    
                    context.IsActive =
                        !user.LockoutEnabled ||
                        !user.LockoutEnd.HasValue ||
                        user.LockoutEnd <= DateTime.Now;
                }
            }
            private async Task<IEnumerable<Claim>> GetClaimsFromUser(ApplicationUser user,ClaimsPrincipal subject)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, user.Id),
                    new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
    
                };
    
                if (!string.IsNullOrWhiteSpace(user.Name))
                    claims.Add(new Claim("name", user.Name));
    
                if (!string.IsNullOrWhiteSpace(user.LastName))
                    claims.Add(new Claim("last_name", user.LastName));
                claims.Add(new Claim(PermissionConstants.PackedPermissionClaimType,
                   await _calcAllowedPermissions.CalcPermissionsForUserAsync(user.Id)));
    
                   if (_userManager.SupportsUserEmail)
                {
                    claims.AddRange(new[]
                    {
                        new Claim(JwtClaimTypes.Email, user.Email),
                        new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                    });
                }
    
                if (_userManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
                {
                    claims.AddRange(new[]
                    {
                        new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                        new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                    });
                }
    
                return claims;
            }
        }

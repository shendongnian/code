    public class CustomWindowsAuthenticationProvider : ISimpleRoleProvider
    {
        public CustomWindowsAuthenticationProvider(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        private UnitOfWork _unitOfWork;
        public Task<ICollection<string>> GetUserRolesAsync(string userName)
        {
            ICollection<string> result = new string[0];
            string[] user = userName.Split("\\");
            var roles = _unitOfWork.UserMod.GetRolesForUser(user[1]);
            if (roles!=null)
                result = roles.Select(d => d.RoleName).ToArray();
        
            return Task.FromResult(result);
        }
    }
    public interface ISimpleRoleProvider
    {
        #region Public Methods
        /// <summary>
        /// Loads and returns the role names for a given user name.
        /// </summary>
        /// <param name="userName">The login name of the user for which to return the roles.</param>
        /// <returns>
        /// A collection of <see cref="string" /> that describes the roles assigned to the user;
        /// An empty collection of no roles are assigned to the user.
        /// </returns>
        /// <remarks>
        ///     <para>Beware that this method is called for each controller call. It might impact performance.</para>
        ///     <para>
        ///     If Windows authentication is used, the passed <paramref name="userName" />
        ///     is the full user name including the domain or machine name (e.g "CostroDomain\JohnDoe" or
        ///     "JOHN-WORKSTATION\JohnDoe").
        ///     </para>
        ///     <para>
        ///     The returned roles names can be used to restrict access to controllers using the <see cref="AuthorizeAttribute" />
        ///     (<c>[Authorize(Roles="...")]</c>
        ///     </para>
        /// </remarks>
        Task<ICollection<string>> GetUserRolesAsync(string userName);
        #endregion
    }
    public class SimpleRoleAuthorizationTransform : IClaimsTransformation
    {
        #region Private Fields
        private static readonly string RoleClaimType = ClaimTypes.Role;//  $"http://{typeof(SimpleRoleAuthorizationTransform).FullName.Replace('.', '/')}/role";
        private readonly ISimpleRoleProvider _roleProvider;
        #endregion
        #region Public Constructors
        public SimpleRoleAuthorizationTransform(ISimpleRoleProvider roleProvider)
        {
            _roleProvider = roleProvider ?? throw new ArgumentNullException(nameof(roleProvider));
        }
        #endregion
        #region Public Methods
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Cast the principal identity to a Claims identity to access claims etc...
            var oldIdentity = (ClaimsIdentity)principal.Identity;
            // "Clone" the old identity to avoid nasty side effects.
            // NB: We take a chance to replace the claim type used to define the roles with our own.
            var newIdentity = new ClaimsIdentity(
                oldIdentity.Claims,
                oldIdentity.AuthenticationType,
                oldIdentity.NameClaimType,
                RoleClaimType);
            // Fetch the roles for the user and add the claims of the correct type so that roles can be recognized.
            var roles = await _roleProvider.GetUserRolesAsync(newIdentity.Name);
            if(roles.Count>0)
                newIdentity.AddClaims(roles.Select(r => new Claim(RoleClaimType, r)));
            
            // Create and return a new claims principal
            return new ClaimsPrincipal(newIdentity);
        }
        #endregion
    }
    public static class SimpleRoleAuthorizationServiceCollectionExtensions
    {
        #region Public Static Methods
        /// <summary>
        /// Activates simple role authorization for Windows authentication for the ASP.Net Core web site.
        /// </summary>
        /// <typeparam name="TRoleProvider">The <see cref="Type"/> of the <see cref="ISimpleRoleProvider"/> implementation that will provide user roles.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> onto which to register the services.</param>
        public static void AddSimpleRoleAuthorization<TRoleProvider>(this IServiceCollection services)
            where TRoleProvider : class, ISimpleRoleProvider
        {
            services.AddScoped<ISimpleRoleProvider, TRoleProvider>();
            services.AddScoped<IClaimsTransformation, SimpleRoleAuthorizationTransform>();
        }
        #endregion
    }

    public class CustomRoleManager : RoleManager<ApplicationRole>
    {
        public CustomRoleManager(IRoleStore<ApplicationRole> store,
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<ApplicationRole>> logger) :
            base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }

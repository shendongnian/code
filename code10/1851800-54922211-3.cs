    public class MockUserManager : UserManager<TUser>
    {
        public MockUserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor,
         IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators,
          IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer,
           IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    
        public override Task<IdentityResult> CreateAsync(TUser user)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }

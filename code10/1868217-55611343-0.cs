     public class MoqUserManager : UserManager<ApplicationUser>
        {
            public MoqUserManager(IUserStore<ApplicationUser> userStore) : base(userStore,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<ApplicationUser>>().Object,
                    new IUserValidator<ApplicationUser>[0],
                    new IPasswordValidator<ApplicationUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
            { }
    
            public override Task<ApplicationUser> FindByEmailAsync(string email)
            {
                return Task.FromResult(new ApplicationUser { Email = email });
            }    
        }

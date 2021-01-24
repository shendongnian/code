    public class LoginModel : MyPageModel
    {
        public LoginModel(AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(db, userManager, signInManager) { }
        // the rest of the class implementation
    }

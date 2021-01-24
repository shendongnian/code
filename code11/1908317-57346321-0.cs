public class UserManager : UserManager<ApplicationUser>
{
    public UserManager() : 
        base(new UserStore<ApplicationUser, IdentityRole>(new ApplicationDbContext()))
    {
    }
}

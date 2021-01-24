    [Authorize(Roles = "Administrator")]
    public class RolesController : BaseController
    {
        public RolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : base(context, userManager, roleManager)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = await RoleManager.Roles.ToListAsync();
            return View(roles);
        }
    }
}

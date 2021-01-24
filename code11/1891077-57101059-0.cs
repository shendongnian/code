    public class DI_BasePageModel : PageModel
        {
            protected ApplicationDbContext Context { get; }
            protected IAuthorizationService AuthorizationService { get; }
            protected UserManager<IdentityUser> UserManager { get; }
            public DI_BasePageModel(
                ApplicationDbContext context,
                IAuthorizationService authorizationService,
                UserManager<IdentityUser> userManager) : base()
            {
                Context = context;
                UserManager = userManager;
                AuthorizationService = authorizationService;
            }
            public SelectList GLRefNameSL { get; set; }
            public void PopulateGLRefDropDownList(ApplicationDbContext _context,     object selectedGLRef = null)
            {
                var GLRefsQuery = from d in _context.GLRef
                                  select d;
                GLRefNameSL = new SelectList(GLRefsQuery.AsNoTracking(), "GLRefID", "Description", selectedGLRef);
            }

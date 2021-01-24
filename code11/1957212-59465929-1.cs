    public class BilgisTableViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public BilgisTableViewComponent(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await db.Bilgis.ToListAsync());
        }
    }

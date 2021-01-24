    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()

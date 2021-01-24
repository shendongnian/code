    [Route("/api/Categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()

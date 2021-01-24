    // API
    namespace ForEvolve.Blog.Samples.NinjaApi.Controllers {
        [Route("v1/[controller]")]
        public class NinjaController : Controller {
            private readonly INinjaService _ninjaService;
            public NinjaController(INinjaService ninjaService) {
                _ninjaService = ninjaService ?? throw new ArgumentNullException(nameof(ninjaService));
            }
    
            [HttpGet]
            [ProducesResponseType(typeof(IEnumerable<Ninja>), StatusCodes.Status200OK)]
            public Task<IActionResult> ReadAllAsync() {
                throw new NotImplementedException();
            }
    
            //...
        }
    }

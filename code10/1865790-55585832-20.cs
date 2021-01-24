    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private MbTilesReader _tileReader;
        public MapController(MbTilesReader tileReader)
        {
            _tileReader = tileReader;
        }
        
        [HttpGet]
        public IActionResult Get(int x, int y, int z)
        {
            byte[] imageData = _tileReader.GetImageData(x, y, z);
            return File(imageData, "image/png");
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FullPillarIdentifierController : BaseController
    {
        private  ILogger<FullPillarIdentifierController> _logger;
        private readonly IFullPillarRepository _pillarRepository;
        private readonly IXmlParser _xmlParser;
        public FullPillarIdentifierController(ILogger<FullPillarIdentifierController> logger, IFullPillarRepository pillarRepository, IXmlParser xmlParser)
        {
            _logger = logger;
            _xmlParser = xmlParser;
            _pillarRepository = pillarRepository;
        }
       
        [HttpPost]
        [Route("getIdentifierPutFileHandlingResponse")]
        public IActionResult CreateMessageOnQueue([FromBody] string xml)
        {
            //...
        }

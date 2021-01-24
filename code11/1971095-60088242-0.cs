    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ILogger<ConvertController> _logger;
        //private readonly Factory.IWorkbookFactory _workbookFactory;
        private readonly IConverter _converter;
        public ConvertController(ILogger<ConvertController> logger,IConverter converter // Factory.IWorkbookFactory workbookFactory)
        {
        _logger = logger;
        //_workbookFactory = workbookFactory;
        _converter=converter;
        }
        [HttpPost]
        [Route("api/v1/[controller]/pdf")]
        public ConvertResponse Post(ConvertRequest req)
        {
            ConvertResponse res = new ConvertResponse();
            res.OutputData = _converter.ExcelToPDF(req.InputData);
            return res;
        }
    }

    public class ValuesController : Controller
    {
        public IConfiguration _configuration { get; }
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            string constr  = _configuration.GetConnectionString("DefaultParkingConnection");
        }
    }

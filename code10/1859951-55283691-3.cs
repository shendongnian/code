    public class DevicesController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(IHttpActionResult))]       
        [ActionName("newDevice")]
        
        public IHttpActionResult NewDevice([System.Web.Http.FromBody] Device device)
        {
            return null;
        }
        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]        
        [ActionName("devices_list")]
        
        public List<Device> GetAllDevices()
        {
            return null;
        }
    }

    public class DefaultController : ApiController {
        private bool IsUserAuthenticated {
            get {
                return User.Identity.IsAuthenticated;
            }
        }
        [HttpGet]
        public IHttpActionResult GetProducts() {
            if (IsUserAuthenticated) { // do something }
            else { // throw 401 }
        }
        [HttpPost]
        public IHttpActionResult Update() {
            if (IsUserAuthenticated) { // do something }
            else { // throw 401 }
        }
        
        //...
        
    }
    

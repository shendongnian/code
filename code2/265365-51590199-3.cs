    public class WebServiceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Insert(SameModel model)
        {
            ...
        }
        
        [HttpPut]
        [IgnoreRequiredValidations]
        public IHttpActionResult Update(SameModel model)
        {
            ...
        }
        
        ...

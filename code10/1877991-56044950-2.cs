    public class DefaultController : ApiController
    {
        [HttpGet]
        public string Default()
        {
            var link = HelperClass.GenerateLink(Request);
            return link;
        }
    }

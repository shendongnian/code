     namespace HIDDEN.Controllers.Sites
     {
         [Authorize]
         [ApiVersion("1.0")]
         [Route("v{version:apiVersion}/sites")]   
         public class valuesV1Controller : ApiController
         {
             // GET: api/values
             public IEnumerable<string> Get()
             {
                 return new string[] { "value1", "value2" };
             }
         }
         [Authorize]
         [ApiVersion("2.0")]
         [ApiVersion("2.1")]
         [Route("v{version:apiVersion}/sites")]
         public class valuesV2Controller : ApiController
         {
             // GET: api/values
             public IEnumerable<string> Get()
             {
                 return new string[] { "value3", "value4" };
             }
         }
     }

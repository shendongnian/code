    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
    namespace AdrianWebApi.Controllers.api
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                return new string[] { "Test 1", " Test 2" };
            }
        }
    }

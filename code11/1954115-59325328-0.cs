    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    namespace webAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                return new string[] { "value1", "value2" };
            }
        
            [HttpPost]
            public string Post(User user)
            {
                string userId = user.id;
                string userEmail = user.email;
                string msg = "There is no posted data!";
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userEmail))
                {
                    WriteToLogFile("User id : " + userId + "\n" + ", User Email : " + userEmail + "\n");
                    msg = "Posted data added successfully!";
                }
                return msg;
            }
        class User {
            public string id { get; set; }
            public string email { get; set; }
        }
    }
 

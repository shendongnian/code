    using Microsoft.AspNetCore.Mvc;
    
    namespace Favlist.Server.Controllers
    {
        [Route("api/[controller]")]
        public class DataFetcher : Controller
        {
            [HttpGet("[action]")]
            public DataClass GetData(string action, string id)
            {
                var str = File.ReadAllTest("data.txt");
                return new DataClass(str);
            }
        }
    }

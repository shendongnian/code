    using Microsoft.AspNetCore.Mvc;
    
    namespace Favlist.Server.Controllers
    {
        [Route("api/[controller]")]
        public class DataFetcher : Controller
        {
            [HttpGet("[action]")]
            public DataClass GetData(string action, string id)
            {
                return DataClass.FromFile("data.txt");
            }
        }
    }

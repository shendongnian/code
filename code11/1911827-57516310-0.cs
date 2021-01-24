    public class HomeController :  ControllerBase
    {
        [HttpGet]
        public async Task<string> Message()
        {
            var response = "Hello World";
            return response;
        }
    }

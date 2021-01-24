    public class GoodController : ApiController
    {
        // OK
        private static readonly HttpClient HttpClient;
    
        static GoodController()
        {
            HttpClient = new HttpClient();
        }
    }

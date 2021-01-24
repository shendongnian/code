    public class AddController : ApiController
    {
    
        // GET api/add?num1=1&num2=2
        public HttpResponseMessage Get(int num1, int num2)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent((num1 + num2).ToString());
    
            return response;
        }
    }

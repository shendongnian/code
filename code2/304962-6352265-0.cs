    [TestFixture]
    public class WebRequestTests : AssertionHelper
    {
        [TestCase("http://www.cnn.com", 200)]
        [TestCase("http://www.foobar.com", 403)]
        [TestCase("http://www.cnn.com/xyz.htm", 404)]
        public void when_i_request_a_url_i_should_get_the_appropriate_response_statuscode_returned(string url, int expectedStatusCode)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = "GET";
            HttpWebResponse webResp;
            try
            {
                webResp = (HttpWebResponse)webReq.GetResponse();
    
                //log a success in a file
            }
            catch (WebException wexc)
            {
                webResp = (HttpWebResponse)wexc.Response;
    
                //log the wexc.Status and other properties that you want in a file
            }
    
            HttpStatusCode statusCode = webResp.StatusCode;
            var answer = webResp.GetResponseStream();
            var result = string.Empty;
    
            if (answer != null)
            {
                using (var tempStream = new StreamReader(answer))
                {
                    result = tempStream.ReadToEnd();
                }
            }
    
            Expect(result.Length, Is.GreaterThan(0), "result was empty");
            Expect(((int)statusCode), Is.EqualTo(expectedStatusCode), "status code not correct");
        }
    }

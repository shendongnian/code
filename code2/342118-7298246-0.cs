    public class WebRequestsTests : WorkItemTest
    {
        [TestMethod, Asynchronous]
        public void TestWebRequest()
        {
            var webRequest = WebRequest.CreateHttp("http://www.stackoverflow.com");
            IAsyncResult result = webRequest.BeginGetResponse(() =>
            {
                EnqueueCallback(() =>
                {
                    WebResponse response = webRequest.EndGetResponse(result);
                    // process response
                    TestComplete(); // async test complete
                });
            });
        }
    }

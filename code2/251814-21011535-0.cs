    [TestClass]
    public class WebRequestTests
    {
        [TestMethod]
        public void TestWebRequestCreate()
        {
            const string uriString = "test://localhost/foo/bar.baz?a=b&c=d";
            var webRequest = new MockWebRequestCreateAssertUrl(uriString);
            Assert.IsTrue(WebRequest.RegisterPrefix("test://localhost/", webRequest),
                          "Failed to register prefix");
            Assert.IsNotNull(WebRequest.Create(uriString));
        }
        public class MockWebRequestCreateAssertUrl : IWebRequestCreate
        {
            private readonly Uri _expectedUri;
            public MockWebRequestCreateAssertUrl(string uriString)
            {
                _expectedUri = new Uri(uriString);
            }
            public WebRequest Create(Uri uri)
            {
                Assert.AreEqual(_expectedUri, uri, "uri parameter is wrong");
                return new MockWebRequestAssertUrl();
            }
        }
        public class MockWebRequestAssertUrl : WebRequest {}
    }

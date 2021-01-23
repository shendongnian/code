    using System;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Silverlight.Testing;
    
    [TestClass]
    public class WebRequestsTests : WorkItemTest
    {
        [TestMethod, Asynchronous]
        public void TestWebRequest()
        {
            var webRequest = WebRequest.CreateHttp("http://www.stackoverflow.com");
    
            webRequest.BeginGetResponse(result =>
            {
                EnqueueCallback(() =>
                {
                    WebResponse response = webRequest.EndGetResponse(result);
    
                    // process response 
    
                    TestComplete(); // async test complete 
                });
            }, null);
        }
    } 

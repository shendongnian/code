    public static class HttpWebResponseDebug
    {
        public static void Assert(HttpWebResponse response)
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            statusNumber = (int)response.StatusCode;
            Assert.AreEqual(200, statusNumber);        
        }
    }
---
    var response = (HttpWebResponse)sd.GetDataType();
    HttpWebResponseDebug.Assert(response);
    // do your thing..

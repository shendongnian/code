    public static class AssertExtensions
    {
        public static void Assert(YourType sd)
        {
            HttpWebResponse response = (HttpWebResponse)sd.GetDataType();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            statusNumber = (int)response.StatusCode;
            Assert.AreEqual(200, statusNumber);
        }
    }

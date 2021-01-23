    public static class Http
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                response = client.UploadValues("http://dork.com/service", new  NameValueCollection()
                {
                    { "home", "Cosby" },
                    { "favorite+flavor", "flies" }
                });
            }
            return response;
        }
    }

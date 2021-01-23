    using System.IO;
    using System.Net;
    using System.Text;
    using System.Collections.Specialized;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var values = new NameValueCollection();
                values.Add("method", "usermgmt.add");
                values.Add("uid_to_add", "5452007164");
                values.Add("api_signature", "");
                values.Add("track", "H40alhZWzp");
    
                var wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, "a=b&c=d");
                wc.Headers.Add(HttpRequestHeader.Referer, "http://www.tagged.com/meetme.html");
    
                var returnBytes = wc.UploadValues("http://domain.com/api/?application_id=user&format=json&session_token=1824dsf1u312asd14", values);
                var returnJson = Encoding.UTF8.GetString(returnBytes);
            }
        }
    }

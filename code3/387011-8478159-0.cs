    using System.Collections.Specialized;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["foo"] = "bar";
                values["bar"] = "baz";
                var url = "http://foo.bar/baz.cgi";
                byte[] result = client.UploadValues(url, values);
                // TODO: do something with the result
                // for example if it represents text you could
                // convert this byte array into a string using the proper
                // encoding: string sResult = Encoding.UTF8.GetString(result);
            }
        }
    }

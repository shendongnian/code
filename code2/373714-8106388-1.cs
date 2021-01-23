    using System;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Web.Script.Serialization;
    
    namespace App
    {
        class Program
        {
            static void Main(string[] args)
            {
                string response = DoRequest();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                View json = ser.Deserialize<View>(response);
                if (json.sucess)
                {
                    // do something.. 
                }
                else
                {
                    Console.WriteLine("Erro:{0}", json.error);
                }
    
            }
    
            static string DoRequest()
            {
                string domain = "..."; // your remote server 
                string post = "foo=baa";
                byte[] data = Encoding.ASCII.GetBytes(post);
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(domain);
                request.Method = "POST";
                request.Referer = "desktop C# Application";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";
    
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
              
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                char[] buffer = new char[256];
                int count;
                StringBuilder buf = new StringBuilder();
                while ((count = sr.Read(buffer, 0, 256)) > 0)
                {
                    buf.Append(buffer, 0, count);
                }
    
                response.Close();
                stream.Close();
                sr.Close();
    
                return buf.ToString();
    
            }
        }
    
        public class View
        {
            public string foo { get; set; }
            public string x { get; set; }
            public bool sucess { get; set; }
            public string error { get; set; }
        }
    }

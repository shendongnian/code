    using System;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    
    class Program
    {
        static void Main()
        {
            var serializer = new JavaScriptSerializer();
            string requestData = serializer.Serialize(new
            {
                c = new
                {
                    make = "Ford",
                    model = "Mustang"
                },
                email = "foo@bar.com",
                phone = "1111"
            });
    
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadData("http://receiving.url/showdata", Encoding.UTF8.GetBytes(requestData));
                Console.WriteLine(Encoding.UTF8.GetString(result));
            }
        }
    }

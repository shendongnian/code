    using System;
    using System.Text;
    using System.Net;
    using System.IO;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                //URL
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
    
                //Basic Authentication
                string authInfo = "admin" + ":" + "adminpw";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpWebRequest.Headers["Authorization"] = "Basic " + authInfo;
    
                //Application Type
                httpWebRequest.ContentType = "application/json";
                
                //Method
                httpWebRequest.Method = "PUT";
    
                // JSON Body
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"ID\":\"1\"," +
                                  "\"Phone\":\"1234567890\"}";
    
                    streamWriter.Write(json);
                    Console.WriteLine("PUT Body: " + json);
                }
    
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
    
                //Status Code
                Console.WriteLine("URL: " + httpWebRequest.RequestUri);
                Console.WriteLine("Status Discription " + httpResponse.StatusDescription);
    
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Status code " +(int)httpResponse.StatusCode + " " + httpResponse.StatusCode);
                }
                else 
                {
                    Console.WriteLine("Status code " + (int)httpResponse.StatusCode + " " + httpResponse.StatusCode);
                }
                // Close the response.
                httpResponse.Close();
            }
        }
    }

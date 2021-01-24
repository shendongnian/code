    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fileId = "zMR4vIPW";
                string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.116 Safari/537.36";
    
                HttpWebRequest request;
                HttpWebResponse response;
    
                // 1: Get cookie from this request
                request = WebRequest.Create("https://workupload.com/file/" + fileId) as HttpWebRequest;
                request.UserAgent = userAgent;
    
                response = request.GetResponse() as HttpWebResponse;
    
                string setHeaderCookieValue = response.Headers["Set-Cookie"];
                string tokenCookieKeyValue = setHeaderCookieValue.Substring(0, setHeaderCookieValue.IndexOf(';'));
    
                response.Close();
    
                // 2: Trick the web server into thinking it's a real user request
                request = WebRequest.Create("https://workupload.com/start/" + fileId) as HttpWebRequest;
                request.UserAgent = userAgent;
                request.Headers["Cookie"] = tokenCookieKeyValue;
    
                response = request.GetResponse() as HttpWebResponse;
                response.Close();
    
                // 3: Call API to get file download URL
                request = WebRequest.Create("https://workupload.com/api/file/getDownloadServer/" + fileId) as HttpWebRequest;
                request.UserAgent = userAgent;
                request.Headers["Cookie"] = tokenCookieKeyValue;
    
                response = request.GetResponse() as HttpWebResponse;
    
                // 4: Get file download URL from JSON response
                using (Stream jsonStream = response.GetResponseStream())
                using (StreamReader jsonStreamReader = new StreamReader(jsonStream, Encoding.UTF8))
                {
                    string responseString = jsonStreamReader.ReadToEnd();
                    string downloadUrl = JsonConvert.DeserializeObject<dynamic>(responseString).data.url;
    
                    response.Close();
    
                    Console.WriteLine("Download URL: " + downloadUrl);
    
                    // 5: Download the actual file
                    request = WebRequest.Create(downloadUrl) as HttpWebRequest;
                    request.UserAgent = userAgent;
                    request.Headers["Cookie"] = tokenCookieKeyValue;
    
                    response = request.GetResponse() as HttpWebResponse;
    
                    using (Stream dataStream = response.GetResponseStream())
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        dataStream.CopyTo(memoryStream);
    
                        byte[] fileContent = memoryStream.ToArray();
    
                        // For debugging purpose only, use FileStream for saving file to disk
                        File.WriteAllBytes("testing.rar", fileContent);
                    }
    
                    response.Close();
                }
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

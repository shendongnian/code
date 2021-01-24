    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace VideoIndexer
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting process");
                var apiUrl = "https://api.videoindexer.ai";
                var accountId = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
                var location = "trial";
                var apiKey = "xxxxxxxxxx";
    
                System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;
    
                // create the http client
                var handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
    
                // obtain account access token
                var accountAccessTokenRequestResult = client.GetAsync($"{apiUrl}/auth/{location}/Accounts/{accountId}/AccessToken?allowEdit=true").Result;
                var accountAccessToken = accountAccessTokenRequestResult.Content.ReadAsStringAsync().Result.Replace("\"", "");
    
                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
    
                // upload a video
                var content = new MultipartFormDataContent();
                Debug.WriteLine("Uploading...");
                // get the video from URL
                //var videoUrl = "https://www.videvo.net/video/young-boy-playing-with-balloons-16/380264/"; // replace with the video URL
    
                // as an alternative to specifying video URL, you can upload a file.
                // remove the videoUrl parameter from the query string below and add the following lines:
                FileStream video = File.OpenRead(@"C:\MV\LAB\VideoIndexer\1.mp4");
                byte[] buffer = new byte[video.Length];
                video.Read(buffer, 0, buffer.Length);
                content.Add(new ByteArrayContent(buffer));
    
                var uploadRequestResult = client.PostAsync($"{apiUrl}/{location}/Accounts/{accountId}/Videos?accessToken={accountAccessToken}&name=some_name&description=some_description&privacy=private&partition=some_partition", content).Result;
                var uploadResult = uploadRequestResult.Content.ReadAsStringAsync().Result;
    
                // get the video id from the upload result
                var videoId = JsonConvert.DeserializeObject<dynamic>(uploadResult)["id"];
                Console.WriteLine("Uploaded");
                Console.WriteLine("Video ID: " + videoId);
    
                // obtain video access token            
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                var videoTokenRequestResult = client.GetAsync($"{apiUrl}/auth/{location}/Accounts/{accountId}/Videos/{videoId}/AccessToken?allowEdit=true").Result;
                var videoAccessToken = videoTokenRequestResult.Content.ReadAsStringAsync().Result.Replace("\"", "");
    
                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
    
                // wait for the video index to finish
                while (true)
                {
                    Thread.Sleep(10000);
    
                    var videoGetIndexRequestResult = client.GetAsync($"{apiUrl}/{location}/Accounts/{accountId}/Videos/{videoId}/Index?accessToken={videoAccessToken}&language=English").Result;
                    var videoGetIndexResult = videoGetIndexRequestResult.Content.ReadAsStringAsync().Result;
    
                    var processingState = JsonConvert.DeserializeObject<dynamic>(videoGetIndexResult)["state"];
    
                    Debug.WriteLine("");
                    Debug.WriteLine("State:");
                    //Debug.WriteLine(processingState);
    
                    // job is finished
                    if (processingState != "Uploaded" && processingState != "Processing")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Full JSON:");
                        Console.WriteLine(videoGetIndexResult);
                        break;
                    }
                }
    
                // search for the video
                var searchRequestResult = client.GetAsync($"{apiUrl}/{location}/Accounts/{accountId}/Videos/Search?accessToken={accountAccessToken}&id={videoId}").Result;
                var searchResult = searchRequestResult.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("");
                Debug.WriteLine("Search:");
                Console.WriteLine(searchResult);
    
                // get insights widget url
                var insightsWidgetRequestResult = client.GetAsync($"{apiUrl}/{location}/Accounts/{accountId}/Videos/{videoId}/InsightsWidget?accessToken={videoAccessToken}&widgetType=Keywords&allowEdit=true").Result;
                var insightsWidgetLink = insightsWidgetRequestResult.Headers.Location;
                Debug.WriteLine("Insights Widget url:");
                Console.WriteLine(insightsWidgetLink);
    
                // get player widget url
                var playerWidgetRequestResult = client.GetAsync($"{apiUrl}/{location}/Accounts/{accountId}/Videos/{videoId}/PlayerWidget?accessToken={videoAccessToken}").Result;
                var playerWidgetLink = playerWidgetRequestResult.Headers.Location;
                Debug.WriteLine("");
                Debug.WriteLine("Player Widget url:");
                Console.WriteLine(playerWidgetLink);
    
                Console.ReadLine();
            }
        }
    }

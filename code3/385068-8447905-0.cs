     using System; 
     using System.Collections.Generic; 
     using System.Linq;
     using System.Web.Script.Serialization;
     
     namespace JSON {
         class Program
         {
             static void Main(string[] args)
             {
                 var json = @"{
         ""authenticated"": true,
         ""user"": ""sathyabhat"",
         ""feeds"": {
             ""96705"": {
                 ""feed_address"": ""http://www.linuxhaxor.net/"",
                 ""updated"": ""8492 hours"",
                 ""favicon_text_color"": null,
                 ""subs"": 35,
                 ""feed_link"": ""http://www.linuxhaxor.net/"",
                 ""favicon_fetching"": true,
                 ""nt"": 0,
                 ""updated_seconds_ago"": 30573336,
                 ""num_subscribers"": 35,
                 ""feed_title"": ""LinuxHaxor.net"",
                 ""favicon_fade"": null,
                 ""exception_type"": ""feed"",
                 ""exception_code"": 503,
                 ""favicon_color"": null,
                 ""active"": true,
                 ""ng"": 0,
                 ""feed_opens"": 0,
                 ""id"": 96705,
                 ""ps"": 0,
                 ""has_exception"": true
             },
             ""768840"": {
                 ""feed_address"": ""http://feeds.feedburner.com/PathikShahDotCom"",
                 ""updated"": ""3 hours"",
                 ""favicon_text_color"": ""black"",
                 ""subs"": 1,
                 ""feed_link"": ""http://www.pathikshah.com/blog"",
                 ""favicon_fetching"": false,
                 ""nt"": 0,
                 ""updated_seconds_ago"": 13043,
                 ""num_subscribers"": 1,
                 ""feed_title"": ""Pathik Shah"",
                 ""favicon_fade"": ""769456"",
                 ""favicon_color"": ""b2d092"",
                 ""active"": true,
                 ""ng"": 0,
                 ""feed_opens"": 0,
                 ""id"": 768840,
                 ""ps"": 0
             },
             ""768842"": {
                 ""feed_address"": ""http://feeds.preshit.net/preshit/blog"",
                 ""updated"": ""3 hours"",
                 ""favicon_text_color"": null,
                 ""subs"": 1,
                 ""feed_link"": ""http://preshit.net"",
                 ""favicon_fetching"": false,
                 ""nt"": 3,
                 ""updated_seconds_ago"": 13536,
                 ""num_subscribers"": 1,
                 ""feed_title"": ""Preshit Deorukhkar"",
                 ""favicon_fade"": null,
                 ""favicon_color"": null,
                 ""active"": true,
                 ""ng"": 0,
                 ""feed_opens"": 1,
                 ""id"": 768842,
                 ""ps"": 0
             },
             ""768843"": {
                 ""feed_address"": ""http://quizwith.net/feed/"",
                 ""updated"": ""3 hours"",
                 ""favicon_text_color"": ""white"",
                 ""subs"": 1,
                 ""feed_link"": ""http://quizwith.net"",
                 ""favicon_fetching"": false,
                 ""nt"": 0,
                 ""updated_seconds_ago"": 11617,
                 ""num_subscribers"": 1,
                 ""feed_title"": ""quizwith.net"",
                 ""favicon_fade"": ""c22900"",
                 ""favicon_color"": ""fe6501"",
                 ""active"": true,
                 ""ng"": 0,
                 ""feed_opens"": 0,
                 ""id"": 768843,
                 ""ps"": 0
             }
         },
         ""flat_folders"": { },
         result: ""ok"" }";
     
                 var jsonSerializer = new JavaScriptSerializer();
                 var response = jsonSerializer.Deserialize<FeedResponse(json);
                 Console.Write(jsonSerializer.Serialize(response));
                 Console.ReadKey();
             }
         }
     
         public class FeedResponse
         {
             public bool authenticated { get; set; }
             public string user { get; set; }
             public Dictionary<string,feed> feeds { get; set; }
             public object flat_folders { get; set; }
             public string result { get; set; }
         }
     
         public class feed
         {
             public string feed_address { get; set; }
             public string updated { get; set; }
             public string favicon_text_color { get; set; }
             public int subs { get; set; }
             public string feed_link { get; set; }
             public bool favicon_fetching { get; set; }
             public string nt { get; set; }
             public string updated_seconds_ago { get; set; }
             public int num_subscribers { get; set; }
             public string feed_title { get; set; }
             public string favicon_fade { get; set; }
             public string exception_type { get; set; }
             public string exception_code { get; set; }
             public string favicon_color { get; set; }
             public bool active { get; set; }
             public string ng { get; set; }
             public int feed_opens { get; set; }
             public int id { get; set; }
             public bool has_exception { get; set; }
         } }

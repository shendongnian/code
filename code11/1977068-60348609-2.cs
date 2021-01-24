    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.YouTube.v3;
    using Google.Apis.YouTube.v3.Data;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    
    
    namespace UploadVideoBlob
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task Run([BlobTrigger("video/{name}", 
                Connection = "DefaultEndpointsProtocol=https;AccountName=uploadvideoblob;AccountKey=XXXX;EndpointSuffix=core.windows.net")]Stream videoBlob, string name,
                Microsoft.Azure.WebJobs.ExecutionContext context, ILogger log)
            {
                UserCredential credential;
                using (var stream = new FileStream(System.IO.Path.Combine(context.FunctionDirectory, "client_secrets.json"), FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        // This OAuth 2.0 access scope allows an application to upload files to the
                        // authenticated user's YouTube channel, but doesn't allow other types of access.
                        new[] { YouTubeService.Scope.YoutubeUpload },
                        "user",
                        CancellationToken.None
                    );
                }
    
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
                });
    
                var video = new Video();
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = "Default Video Title";
                video.Snippet.Description = "Default Video Description";
                video.Snippet.Tags = new string[] { "tag1", "tag2" };
                video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", videoBlob, "video/*");
                await videosInsertRequest.UploadAsync();
            }
        }
    }

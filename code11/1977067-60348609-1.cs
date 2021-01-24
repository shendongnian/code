        namespace UploadVideoToYoutube
    {
    	public static class Function1
    	{
    		[FunctionName("Function1")]
    		public static async Task RunAsync([BlobTrigger("blob-container-name/{fileName}")] Stream videoBlob, string fileName, ExecutionContext context, ILogger log)
    		{
    			log.LogInformation("C# HTTP trigger function processed a request.");
    
    			log.LogInformation("YouTube Data API: Upload Video");
    			log.LogInformation("==============================");
    
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

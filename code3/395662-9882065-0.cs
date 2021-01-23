    CreateAuthenticatedRequest().Service.Delete(new Uri(GetVideoUploadUrl(videoId)));
    
        public static YouTubeRequest CreateAuthenticatedRequest()
        {
            YouTubeRequestSettings settings = new YouTubeRequestSettings(ConfigurationManager.AppSettings["GData.AppName"],  ConfigurationManager.AppSettings["GData.DeveloperKey"], ConfigurationManager.AppSettings["GData.Email"], ConfigurationManager.AppSettings["GData.Password"]);
            settings.Timeout = 1000000;
            return new YouTubeRequest(settings);
        }
    
        private static string GetVideoUploadUrl(string videoId)
        {
            return string.Format("http://gdata.youtube.com/feeds/api/users/default/uploads/{0}", videoId);
        }

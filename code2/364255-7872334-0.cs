        public void **GetMediaFile**(string httpPath)
        {
            WebClient wcMedia = new WebClient();
            wcMedia.OpenReadAsync(new Uri(httpPath));
            wcMedia.OpenReadCompleted += new OpenReadCompletedEventHandler(wcMedia_OpenReadCompleted);
            wcMedia.AllowReadStreamBuffering = true;
        }

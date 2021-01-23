    public string YouTubeUrl { get; set; }
    public string YouTubeVideoId
    {
        get
        {
            var youtubeMatch =
                new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)")
                .Match(this.YouTubeUrl);
            return youtubeMatch.Success ? youtubeMatch.Groups[1].Value : string.Empty;
        }
    }

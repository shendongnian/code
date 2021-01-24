    public async void SetDataPlayer()
    {
        _loadAnimationListener?.FinishLoadAnimation();
        var videoURL = await YouTube.GetVideoUriAsync("Bey4XXJAqS8", YouTubeQuality.Quality1080P);
        Media.Source = MediaSource.CreateFromUri(videoURL.Uri);
    }

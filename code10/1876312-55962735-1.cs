    public async void SetDataPlayer()
    {
        _loadAnimationListener?.FinishLoadAnimation();
        var videoURL = await YouTube.GetVideoUriAsync("Bey4XXJxxxxx", YouTubeQuality.Quality1080P);
        Media.Source = MediaSource.CreateFromUri(videoURL.Uri);
    }

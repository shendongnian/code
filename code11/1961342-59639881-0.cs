    public async Task<IActionResult> LoadVideosViewComponent()
    {
        var videos = await _db.Videos;
    
        return ViewComponent("Videos", videos);
    }

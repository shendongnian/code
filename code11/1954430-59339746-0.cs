public async Task<T> GetFromChannel<T>(
    string channelID,
    Func<Task<T>> resultGetter,
    bool forceRefresh = false)
{
    string barrelURL = "GetPlaylistsFromChannel" + channelID.Trim();
    T results = default;
    if (forceRefresh != true)
    {
        results = GetCached<T>(barrelURL);
    }
    else
    {
        try
        {
            if (object.Equals(results, default(T)))
            {
                results = await resultGetter();
                Barrel.Current.Add(barrelURL, results, TimeSpan.FromDays(30));
            }
            return results;
        }
        catch (Exception ex)
        {
            Crashes.TrackError(ex);
        }
    }
    return results;
}
And then you can insert the differing parts using other methods or lambda exressions, for example:
public Task<PlaylistListResponse> GetPlaylistsFromChannel(
    string channelID,
    bool forceRefresh = false)
{
    return GetFromChannel<PlaylistListResponse>(
        channelID,
        async () =>
        {
            var videosFromPlaylistRequest = youtubeService.PlaylistItems.List("snippet");
            videosFromPlaylistRequest.PlaylistId = playlistID;
            videosFromPlaylistRequest.MaxResults = 50;
            return await videosFromPlaylistRequest.ExecuteAsync();
        },
        forceRefresh);
}

class MediaSessionCallback : MediaSession.Callback
{
	public Action OnPlayImpl { get; set; }
	public Action<long> OnSkipToQueueItemImpl { get; set; }
	public Action<long> OnSeekToImpl { get; set; }
	public Action<string, Bundle> OnPlayFromMediaIdImpl { get; set; }
	public Action OnPauseImpl { get; set; }
	public Action OnStopImpl{ get; set; }
	public Action OnSkipToNextImpl{ get; set; }
	public Action OnSkipToPreviousImpl{ get; set; }
	public Action<string, Bundle> OnCustomActionImpl { get; set; }
	public Action<string, Bundle> OnPlayFromSearchImpl { get; set; }
	public override void OnPlay ()
	{
		OnPlayImpl ();
	}
	public override void OnSkipToQueueItem (long id)
	{
		OnSkipToQueueItemImpl (id);
	}
	public override void OnSeekTo (long pos)
	{
		OnSeekToImpl (pos);
	}
	public override void OnPlayFromMediaId (string mediaId, Bundle extras)
	{
		OnPlayFromMediaIdImpl (mediaId, extras);
	}
	public override void OnPause ()
	{
		OnPauseImpl ();
	}
	public override void OnStop ()
	{
		OnStopImpl ();
	}
	public override void OnSkipToNext ()
	{
		OnSkipToNextImpl ();
	}
	public override void OnSkipToPrevious ()
	{
		OnSkipToPreviousImpl ();
	}
	public override void OnCustomAction (string action, Bundle extras)
	{
		OnCustomActionImpl (action, extras);
	}
	public override void OnPlayFromSearch (string query, Bundle extras)
	{
		OnPlayFromSearchImpl (query, extras);
	}
}
And use it like this:
var mediaCallback = new MediaSessionCallback ();
mediaCallback.OnPlayImpl = () => {
	LogHelper.Debug (Tag, "play");
};
mediaCallback.OnSkipToQueueItemImpl = (id) => {
	LogHelper.Debug (Tag, "OnSkipToQueueItem:" + id);
};
mediaCallback.OnSeekToImpl = (pos) => {
	LogHelper.Debug (Tag, "onSeekTo:", pos);
};
mediaCallback.OnPlayFromMediaIdImpl = (mediaId, extras) => {
	LogHelper.Debug (Tag, "playFromMediaId mediaId:", mediaId, "  extras=", extras);
};
mediaCallback.OnPauseImpl = () => {
	LogHelper.Debug (Tag, "pause. current state=" + playback.State);
};
mediaCallback.OnStopImpl = () => {
	LogHelper.Debug (Tag, "stop. current state=" + playback.State);
};
mediaCallback.OnSkipToNextImpl = () => {
	LogHelper.Debug (Tag, "skipToNext");
};
mediaCallback.OnSkipToPreviousImpl = () => {
};
mediaCallback.OnCustomActionImpl = (action, extras) => {
};
mediaCallback.OnPlayFromSearchImpl = (query, extras) => {
	LogHelper.Debug (Tag, "playFromSearch  query=", query);
};
Luckily for you, there is even a sample for the implementation of a music service:
https://github.com/xamarin/monodroid-samples/blob/master/android5.0/MediaBrowserService/MediaBrowserService/MusicService.cs

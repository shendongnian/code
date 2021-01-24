    private async void PlaybackSession_PositionChanged(MediaPlaybackSession sender, object args)
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            CurentPosition = (int)sender.Position.TotalSeconds;
            progressbar.Value = (CurentPosition / MusicTime) *100;
           
        });
    }

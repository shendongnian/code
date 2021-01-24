    private async void Player_MediaOpened(MediaPlayer sender, object args)
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            MusicTime = (int)sender.PlaybackSession.NaturalDuration.TotalSeconds();
            
        });
    }

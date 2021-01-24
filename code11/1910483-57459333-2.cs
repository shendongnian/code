    private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {​
                var source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/xxx"));​
    ​
                // Create a configurable playback item backed by the media source​
                var playbackItem = new MediaPlaybackItem(source);​
                MediaPlayer player = new MediaPlayer();​
                MediaPlaybackList lists = new MediaPlaybackList();​
                lists.Items.Add(playbackItem);​
                player.Source = lists;​
    ​
            }

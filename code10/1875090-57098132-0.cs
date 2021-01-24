            if (isHLS)
            {
                var item = await CrossMediaManager.Current.MediaExtractor.CreateMediaItem(URL);
                item.MediaType = MediaManager.Media.MediaType.Hls;
                CrossMediaManager.Current.MediaPlayer.VideoView.ShowControls = false;
                await CrossMediaManager.Current.Play(item);
            }
            else
            {
                await CrossMediaManager.Current.Play(URL);
            }

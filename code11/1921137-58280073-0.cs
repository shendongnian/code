        public static async Task SetPlaylist(ICollection<Music> playlist)
        {
            if (CurrentPlaylist.Count > 0) Clear();
            foreach (var item in playlist)
                await AddMusic(item);
            if (!CurrentPlaylist.Contains(CurrentMusic))
                CurrentMusic = null;
        }
        public static async void ShuffleOthers()
        {
            PendingPlaybackList = new MediaPlaybackList();
            var playlist = ShufflePlaylist(CurrentPlaylist, CurrentMusic);
            CurrentPlaylist.Clear();
            foreach (var item in playlist)
                await AddMusic(item);
            CurrentPlaylist[0].IsPlaying = true;
        }

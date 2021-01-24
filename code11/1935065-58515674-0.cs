    public static void PlayTrack(List<string> tracks, int i)
    {
        while (true)
        {
            if (i == tracks.Count)
            {
                tracks = MusicPlayer.ShufflePlaylist(tracks, MusicPlayer.random);
                i = 0;
            }
            music.SoundLocation = tracks[i];
            int l = SoundInfo.GetSoundLength(tracks[i]);
            music.Play();
            for (int q = 0; q <= l; q++)
                Thread.Sleep(1000);
            i++;
        }
    }

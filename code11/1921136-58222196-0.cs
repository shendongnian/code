    public static async Task SetPlaylist(ICollection<Music> playlist, Music music = null)
    {
        int index = 0;
        foreach (var item in playlist.Skip(1))
        {
            index++;
            await FayAddMusic(item, index);
        }
    
        if (!CurrentPlaylist.Contains(CurrentMusic))
            CurrentMusic = null;
    
    }
    
    public static async Task FayAddMusic(Music music, int index)
    {
        try
         {
             var file = await StorageFile.GetFileFromPathAsync(music.Path);
             var source = MediaSource.CreateFromStorageFile(file);
             music.IsPlaying = false;
             source.CustomProperties.Add("Source", music);
             var item = new MediaPlaybackItem(source);
             // update element
             PlayBackList.Items[index] = item;
             CurrentPlaylist[index] = music;
          }
          catch (System.IO.FileNotFoundException)
          {
    
    
          }
    }

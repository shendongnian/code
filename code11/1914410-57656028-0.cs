    foreach (var music in PlayList.ShuffledItems)
    {​
        MediaSource source = music.Source;​
        String path = sour.CustomProperties["Path"].ToString();​
        ShuffledPlayList.Add(await Music.GetMusic(path));​
    }

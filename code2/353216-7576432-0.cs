    public Stream GetMusicInfo(string songId)
    {
        XElement data = dao.GetMusicInfo(songId);
        MemoryStream ms = new MemoryStream();
        data.Save(ms);
        ms.Position = 0;
        return ms;
    }

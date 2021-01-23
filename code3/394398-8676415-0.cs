    public static Collection<MediaInfo> imagePlaylist
    
    imagePlaylist = new Collection<MediaInfo>
                        (
                           imagePlaylist
                          .Distinct(new API.MediaInfoComparer())
                          .ToList()
                        );

    public String GetPhotoLink(string photoID)
    {
        var fb = new FacebookWebClient();
        dynamic albums = fb.Get("me/albums");
        foreach (dynamic albumInfo in albums.data)
        {
            dynamic photos = fb.Get(albumInfo.id + "/photos");
            foreach (var photo in photos.data)
            {
                if (photo.id == photoID)
                {
                    return photo.link;
                }
            }
        }
        return String.Empty;
    }

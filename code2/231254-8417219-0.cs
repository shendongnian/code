    PhotoQuery query = new PhotoQuery(PicasaQuery.CreatePicasaUri("default", albumId));
            PicasaFeed feed = picasaService.Query(query);
            foreach (var entry in feed.Entries)
            {
                PhotoAccessor photoAccessor = new PhotoAccessor((PicasaEntry)entry);
                Photo photo = new Photo();
                photo.Title = photoAccessor.PhotoTitle;
                photo.Summary = photoAccessor.PhotoSummary;
                photo.MediaUri = entry.Content.AbsoluteUri;
                photo.Id = photoAccessor.Id;
                photo.AlbumId = photoAccessor.AlbumId;
                photos.Add(photo);
            }

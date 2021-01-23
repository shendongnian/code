                 };
    public static Artist ProcessArtist(RArtist artist, Entities db) {
        var artistLookup = db.Artist.SingleOrDefault(x => x.ExternalId == artist.ExternalId);
        if (artistLookup == null) {
            artistLookup = new Artist {
                ExternalId = artist.ExternalId,
                Name = artist.Name
            };
            db.Artist.AddObject(artistLookup);
            db.SaveChanges();
        }
        return artistLookup;
    }
    foreach (var album in albums) {
        Album a = new Album();
        // copy properties of a from album
        a.Artist = ProcessArtist(album.Artist, db);
        db.Album.AddObject(a);
    }

    public class LastFmAlbumArt
    {
        public static string AbsUrlOfArt(SpotiKatSpotify.Entity.Album album, string artist)
        {
            Lastfm.Services.Session session = new Lastfm.Services.Session("XXXXXX", "YYYYYY");
            Lastfm.Services.Artist lArtist = new Lastfm.Services.Artist(artist, session);
            Lastfm.Services.Album lAlbum = new Lastfm.Services.Album(lArtist, album.Name, session);
            return lAlbum.GetImageURL();
        }
        public static Image AlbumArt(SpotiKatSpotify.Entity.Album album, string artist)
        {
            Stream stream = null;
            try
            {
                WebRequest req = WebRequest.Create(AbsUrlOfArt(album, artist));
                WebResponse response = req.GetResponse();
                stream = response.GetResponseStream();
                Image img = Image.FromStream(stream);
                
                return img;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if(stream != null)
                    stream.Dispose();
            }
        }
    }

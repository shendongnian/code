    public static class ExtensionMethods
    {
        public static IEnumerable<MediaItem> ToMediaItems(this IEnumerable<Track> tracks)
        {
            return from t in tracks
                   select new MediaItem
                   {
                       artist = t.Artist,
                       title = t.Title,
                       // blah blah
                   };
        }
    }

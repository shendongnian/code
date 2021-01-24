    public static class AlbumsExtensions
    {
        public static bool Match(this Album album, string search)
        {
            // whatever complex logic you have stays here
            var search = searchString.ToLower();
            var result = p.Name.ToLower().Contains(search) ||
                         p.Artist.ToLower().Contains(search) ||
                         p.Genre.ToLower().Contains(search);
            return result ;
        }
    }

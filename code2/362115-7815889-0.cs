    static class PostQueryExtensions
    {
        public static IQueryable<PostViewModel> Materialize(this IQueryable<Post> query)
        {
            return from post in query
                   select new PostViewModel()
                   {
                       ....
                   }
        }
    }
    class PostDataAccess
    {
        public IEnumerable<PostViewModel> GetOldest()
        {
            var query = db.Posts
                          .OrderBy(x => x.DateCreated)
                          .Materialize();
        }
        public IEnumerable<PostViewModel> GetNewest()
        {
            var query = db.Posts
                          .OrderByDescending(x => x.DateCreated)
                          .Materialize();
        }
    }

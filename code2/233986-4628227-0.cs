    public IQueryable<UserData> GetUsersWithPosts()
    {
        return from u in UserRepository.GetUsers()
               select new UserData 
               {
                   Id = u.Id,
                   Name = u.Name
                   Posts = from p in u.Posts
                           select new PostData
                           {
                               Id = u.Id,
                               Title = p.Title
                           }
               };

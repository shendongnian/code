    public enum PostType
    {
        Oldest,
        Newest,
        ForUser,
        ByCat
    }
    public List<PostViewModel> GetPosts(PostType pt, YourDataContext db, int UserId = 0)
    {
        List<PostViewModel> v = db.Posts.Select(i => new PostViewModel() { /* snip */});
        switch(pt)
        {
            case pt.Oldest:
                v = v.Where(i => p.StatusID == (int)PostStatus.Visible).OrderDescendingBy(i => i.DateCreated).ToList();
                break;
            case pt.ByUser:
                v = v.Where(i => p.UserId == UserId).ToList();
                break;
               ...
        }   
        return v;
    }
  

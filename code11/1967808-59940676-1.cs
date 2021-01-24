    public async Task<IActionResult> Index()
    {
        var posts = await _context.Posts.ToListAsync();
        var postList = new List<PostIndexModel>();
        foreach (var p in  posts)
        {
            var userName = (from u in _context.Users
                        where u.Id.Equals(p.UserId)
                        select u.UserName).SingleOrDefault();
            var post = new PostIndexModel()
            {
                PostId = p.PostId,
                PostName = p.PostName,
                UserName = userName
            };
            postList.Add(post);
        }
        return View(postList);
    }

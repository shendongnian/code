    var thread = _appDbContext.Threads
                    .Include(t => t.Posts)
                    .ThenInclude(p => p.ApplicationUser)
                    .Include(t => t.ApplicationUser).Where(t => t.Id == id).Select(t => new
    {
        title = t.Title,
        body = t.Body,
        threadUserName = t.ApplicationUser.UserName,
        postsThread = t.Posts.Select(p => new {
            p.Content,
            p.ApplicationUser.UserName
        })
    }).ToList();

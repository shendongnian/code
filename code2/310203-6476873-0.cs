    public ActionResult ViewTopic (int id)
        {
            ForumDBE forumDB = new ForumDBE();
            var posts = forumDB.Post; // or you can use .ToList() but I prefer to use IQueryable
            return View(posts);
        }

    tblBlogEntry myBlog;
    if (EntryID != -1) {
      myBlog = db.tblBlogEntries
        .SingleOrDefault(blog => blog.ID == EntryID);
    } else {
      myBlog = db.tblBlogEntries
        .OrderByDescending(blog => blog.date)
        .FirstOrDefault();
    }
    dynamic q = new {
      myBlog.ID,
      myBlog.title,
      myBlog.entry,
      myBlog.date,
      myBlog.userID,
      Comments = db.tblBlogComments.Where(comment => comment.blogID == myBlog.ID).Count(),
      Username = new { db.yaf_Users.Single(user => user.UserID == myBlog.userID).DisplayName }
    }

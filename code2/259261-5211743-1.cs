    tblBlogEntry myBlog;
    if (EntryID != -1) {
      myBlog = db.tblBlogEntries
        .SingleOrDefault(blog => blog.ID == EntryID);
    } else {
      myBlog = db.tblBlogEntries
        .OrderByDescending(blog => blog.date)
        .FirstOrDefault();
    }
    this.Loaded = myBlog != null;
    if (this.Loaded) {
      this.ID = myBlog.ID;
      this.Title = myBlog.title;
      this.Entry = myBlog.entry;
      this.Date = (DateTime)myBlog.date;
      this.UserID = (int)myBlog.userID;
      this.AuthorUsername = db.yaf_Users
          .Single(user => user.UserID == myBlog.userID)
          .DisplayName;
      this.Comments = db.tblBlogComments
          .Where(comment => comment.blogID == myBlog.ID)
          .Count();
    } 

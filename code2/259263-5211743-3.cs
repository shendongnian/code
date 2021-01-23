    tblBlogEntry myBlog;
    if ( EntryID != -1 ) 
    {
      myBlog = db.tblBlogEntries
                 .SingleOrDefault( blog => blog.ID == EntryID );
    }
    else 
    {
      myBlog = db.tblBlogEntries
                 .OrderByDescending( blog => blog.date ).FirstOrDefault();
    }
    this.Loaded = myBlog != null;
    if ( this.Loaded )
    {
      this.ThisEntry = new EntryModel
      {
        ID = myBlog.ID,
        Title = myBlog.title,
        Entry = myBlog.entry,
        Date = ( DateTime )myBlog.date,
        UserID = ( int )myBlog.userID,
        Username = db.yaf_Users
                     .Single( user => user.UserID == myBlog.userID ).DisplayName,
        Comments = db.tblBlogComments
                     .Where( comment => comment.blogID == myBlog.ID ).Count()
      }
    } 

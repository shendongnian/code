    / Loads by Entry ID, or if -1, by latest entry
    private void LoadEntryByID(int EntryID)
    {
        dynamic q = null;
        if (EntryID == -1)
        {
            q = (from Blog in db.tblBlogEntries
                 orderby Blog.date descending
                 select new
                 {
                     Blog.ID,
                     Blog.title,
                     Blog.entry,
                     Blog.date,
                     Blog.userID,
                     Comments = (from BlogComments in db.tblBlogComments where BlogComments.blogID == Blog.ID select BlogComments).Count(),
                     Username = (from Users in db.yaf_Users where Users.UserID == Blog.userID select new { Users.DisplayName }).SingleOrDefault()
                 }).FirstOrDefault();
        }
        else
        {
            q = (from Blog in db.tblBlogEntries
                     where Blog.ID == EntryID
                     select new
                     {
                         Blog.ID,
                         Blog.title,
                         Blog.entry,
                         Blog.date,
                         Blog.userID,
                         Comments = (from BlogComments in db.tblBlogComments where BlogComments.blogID == Blog.ID select BlogComments).Count(),
                         Username = (from Users in db.yaf_Users where Users.UserID == Blog.userID select new { Users.DisplayName }).SingleOrDefault()
                     }).SingleOrDefault();
        }
        if (q == null)
        {
            this.Loaded = false;
        }
        else
        {
            this.ID = q.ID;
            this.Title = q.title;
            this.Entry = q.entry;
            this.Date = (DateTime)q.date;
            this.UserID = (int)q.userID;
            this.Loaded = true;
            this.AuthorUsername = q.Username;
        }       
    }
}

    public class EntryModel
    {
       public int ID {get;set;}
       public string Title {get;set;}
       public string Entry{get;set;}
       public DateTime Date {get;set;}
       public int UserID {get;set;}
       public List<Comment> Comments {get;set;}
    }
    // Loads by Entry ID, or if -1, by latest entry
    private void LoadEntryByID(int EntryID)
    {
       EntryModel q;
       if (EntryID == -1)
       {
           q = (from Blog in db.tblBlogEntries
           orderby Blog.date descending
           select  select new EntryModel()
           {
               ID=Blog.ID,
               Title=Blog.title,
               Entry=Blog.entry,
                     Date=Blog.date,
                     UserId=Blog.userID,
                     Comments = (from BlogComments in db.tblBlogComments where     BlogComments.blogID == Blog.ID select BlogComments).Count()
                 }).SingleOrDefault();
            }
            else
            {
                q = (from Blog in db.tblBlogEntries
                         where Blog.ID == EntryID
                         select select new EntryModel()
                 {
                     ID=Blog.ID,
                     Title=Blog.title,
                     Entry=Blog.entry,
                     Date=Blog.date,
                     UserId=Blog.userID,
                     Comments = (from BlogComments in db.tblBlogComments where     BlogComments.blogID == Blog.ID select BlogComments).Count()
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

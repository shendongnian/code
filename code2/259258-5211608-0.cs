       // Loads by Entry ID, or if -1, by latest entry
        private void LoadEntryByID(int EntryID)
        {
            tblBlogEntry q;
            if (EntryID == -1)
            {
                q = (from Blog in db.tblBlogEntries
                     orderby Blog.date descending
                     select Blog).SingleOrDefault();
            }
            else
            {
                q = (from Blog in db.tblBlogEntries
                         where Blog.ID == EntryID
                         select Blog).SingleOrDefault();
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

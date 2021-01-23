    public List<int> AuthorIDs
    {
        get
        {
            var l = new List<int>();
            using (var context = new GarbageEntities())
            {
                foreach (var author in context.Authors.Where(a => a.Books.Any(b => b.BookID == this.BookID)).ToList())
                {
                    l.Add(author.AuthorID);
                }
            }
            return l;
        }
        set{
           this.SetPropertyValue(page => page.AuthorIDs, value);
        }
    }

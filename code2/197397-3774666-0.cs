    private List<int> authorIDs;
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
    
        set{authorIDs = value; //this does not make much sense though ... what are you trying to do by setting authorIDs?
    }
    }

    public List<int> GetAuthorIDs(int bookId)
        {
                var l = new List<int>();
                using (var context = new GarbageEntities())
                {
                    foreach (var author in context.Authors.Where(a => a.Books.Any(b => b.BookID == bookId)).ToList())
                    {
                        l.Add(author.AuthorID);
                    }
                }
                return l;
            }

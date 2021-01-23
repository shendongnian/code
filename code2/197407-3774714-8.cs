    public class BookService()
    {
        public List<int> GetAuthorIDs(int bookId)
        {
            var authorIds = new List<int>();
            using (var context = new GarbageEntities())
            {
                foreach (var author in context.Authors.Where(a => a.Books.Any(b => b.BookID == bookId)).ToList())
                {
                    authorIds.Add(author.AuthorID);
                }
            }
            return authorIds;
        }
    }

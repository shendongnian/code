IQueryable query = dbContext.Blogs;
if (isSo)
{
    query = query.Where(...);
}
query.ToArray();
  [1]: http://SqlKata.com

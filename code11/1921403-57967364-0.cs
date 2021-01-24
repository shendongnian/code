    public class MyDbContext : DbContext
    {
        public async Task<IList<Foo>> GetFooAsync(int n) where T : class
        {
           var query = base.Database.SqlQuery<Foo>("exec fooStoredProc @n",
               new SqlParameter("@n", n));
           return await query.ToListAsync();
        }
    }

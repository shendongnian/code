    public class Data
    {
        public async Task<History> GetHistoryById(int id)
        {
            using (var context = CreateDbContext())
            {
                return await context.History.FirstOrDefaultAsync(h => h.Id == id);
            }
        }
        public async Task<History> GetOtherByName(string name)
        {
            using (var context = CreateDbContext())
            {
                return await context.OtherTable.FirstOrDefaultAsync(o => o.Name == name);
            }            
        }
        public async Task<IEnumerable<MyObject>> GetObjects()
        {
            using (var context = CreateDbContext())
            {
                return await context.Objects.ToListAsync();
            }            
        }
        private CustomDbContext CreateDbContext()
        {
             var options = new DbContextOptionsBuilder<CustomDbContext>()
                 .UseSqlServer(_connectionString)
                 .Options;
             return new CustomDbContext(options);
        }
    }

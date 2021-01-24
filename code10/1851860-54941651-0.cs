     public class OvertimeRequestBusiness
        {
            public static OvertimeRequestBusiness Instance { get; } = new OvertimeRequestBusiness();
         
            DbContextOptionsBuilder<DatabaseContext> _optionsBuilder;
            
    
            public OvertimeRequestBusiness() {
                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(@"ConnectionString");
                _optionsBuilder = optionsBuilder;
            }
      public async Task<List<User>> GetAllUsersAsync()
            {
                using (var ctx = new DatabaseContext(_optionsBuilder.Options))
                {
                    var query = ctx.Users;
                    var res = await query.ToListAsync();
                    return res;
                }
            }
    
        }

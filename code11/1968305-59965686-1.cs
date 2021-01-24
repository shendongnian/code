    public class MyController
    {
        private readonly ApplicationDbContext _dbContext;
        public MyController(ApplicationDbContextcontext dbContext)
        {
            _dbContext = dbContext;
        }
        private void MethodA()
        {
          //accessing dbcontext
          _dbContext.MyTable.ToList();
        }
    }

    public class MyController
    {
        private readonly ApplicationDbContext _dbContext;
        public MyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private void MethodA()
        {
          //accessing dbcontext
          _dbContext.MyTable.ToList();
        }
    }

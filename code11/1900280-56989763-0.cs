    public class EFService : IService
    {
        private readonly MyDbContext _context;
        public EFService(MyDbContext context)
        {
            _context = context;
        }
        public void DoSomething()
        {
            // use _context
        }
    }

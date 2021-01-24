    public class VisitorRepository : IVisitorRepository 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Visitor> _visitors;
    
        public VisitorRepository(ApplicationDbContext context) 
        {
            _context = context;
            _visitors = _context.Visitors;
        }
        .........
    }

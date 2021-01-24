    public class MyController
    {
        private readonly EmployeeContext _context;
    
        public MyController(EmployeeContext context)
        {
          _context = context;
        }
    
        ...
    }

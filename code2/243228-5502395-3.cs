    public class UserRepository : IRepository<Position>    
    {
        private myContext _context;
        public UserRepository (IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
 
            _context = unitOfWork as myContext;
        }
        /// other methods ///
    }

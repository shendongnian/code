        public interface IUserRepository : IRepository<User>
        {
        // some additional properties specific to User repository
        ...
        }
        
        public class UserRepository : EntityRepository<User>, IUserRepository
        {
        
                // you can also implement unit of work here
                public UserRepository(IUnitOfWork uow)
                    : base(uow)
                {
                }    
        }

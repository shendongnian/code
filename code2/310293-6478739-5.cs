        public interface IUserRepository : IRepository<User>
        {
        // some additional properties specific to User repository
        ...
        }
        
        public class UserRepository : EntityRepository<User>, IUserRepository
        {
                public UserRepository(IUnitOfWork uow)
                    : base(uow)
                {
                }    
        }

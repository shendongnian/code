	public interface ConcreteUserRepo : IUserRepository
	{}
	public interface IUserRepository : IRepository<User>
	{}
	public interface IRepository<User>
	{}
	public class User
	{}

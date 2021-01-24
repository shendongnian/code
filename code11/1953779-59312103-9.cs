	public class BasePost : IPost
	{
		public int Id { get; set; }
	}
	public class Repo<T> : IRepo<BasePost> where T : BasePost
	{
		public void Add(BasePost post)
		{
		}
	}
	public abstract class Service : IService<IPost>
	{
		public IRepo<IPost> Repository { get; private set; }
		public Service(IRepo<IPost> repository)
		{
			this.Repository = repository;
		}
		public abstract void Run();
	}

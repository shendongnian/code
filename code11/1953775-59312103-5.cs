	public abstract class Service : IService<IPost>
	{
		public IRepo<IPost> Repository { get; private set; }
		public Service(IRepo<IPost> repository)
		{
			this.Repository = repository;
		}
		public abstract void Run();
	}

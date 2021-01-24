	public interface IPost
	{
		int Id { get; }
	}
	public interface IRepo<out T> where T : IPost
	{
		void Add(BasePost post);
	}
	public interface IService<T> where T : IPost
	{
		IRepo<T> Repository { get; }
		void Run();
	}

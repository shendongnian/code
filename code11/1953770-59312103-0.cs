    public interface IService<out T> where T: BasePost
    {
    	T Model { get; }
    	void Run();
    }

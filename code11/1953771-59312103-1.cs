    // The additional T of type BasePost is for constructor argument in Child class 
	public abstract class Service<T> : IService<BasePost> where T: BasePost
	{
		public BasePost Model { get; private set; }
        // Enforces dependency injection
		public Service(T post)
		{
			this.Model = post;
		}
		public abstract void Run();
	}

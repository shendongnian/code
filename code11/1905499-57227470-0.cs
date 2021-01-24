    public interface IEntity<T>
	{
		T Id {get;set;}
	}
	
	public interface IRepository<T, TPrimaryKey> where T: IEntity<TPrimaryKey>{}
	
	public class BaseRepository<T, TPrimaryKey> : IRepository<T, TPrimaryKey> where T: class, IEntity<TPrimaryKey>{}
	
	public class Queue : IEntity<int>
	{
		public int Id {get;set;}
	}
    
	public class QueueRepository : BaseRepository<Queue, int>
	{
	}
	
	public class QueueController
	{
		//Not a good idea
		private readonly BaseRepository<Queue, int> queueRepository;
		
		//Better
		private readonly QueueRepository _queueRepository;
	}

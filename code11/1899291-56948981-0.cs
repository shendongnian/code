	public class Shuffler
	{
		private static Random Random = new Random();
		
		private readonly Queue<int> _queue;
		
		public Shuffler(int max)
		{			
			_queue = new Queue<int>(Enumerable.Range(1, max).OrderBy(x => Random.Next()));
		}
		
		public int GetNext()
		{
			if(_queue.Count == 0)
			{
				//no more items, throw
			}
			
			return _queue.Dequeue();
		}
	}

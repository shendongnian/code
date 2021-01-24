	public class Shuffler
	{
		private static Random rnd = new Random();
		
		private readonly Queue<int> _queue;
		
		public Shuffler(int max)
		{			
			_queue = new Queue<int>(Enumerable.Range(1, max).OrderBy(x => rnd.Next()));
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

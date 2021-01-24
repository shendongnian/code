	public class Shuffler
	{
		private static Random rnd = new Random();
		
		private readonly Queue<int> _queue;
		
		public Shuffler(int max)
		{			
			_queue = new Queue<int>(Enumerable.Range(1, max).OrderBy(x => rnd.Next()));
		}
		
		public bool TryGetNext(out int item)
		{
			if(_queue.Count == 0)
			{
				item = -1;
                return false;
			}
			
			item = _queue.Dequeue();
            return true;
		}
	}

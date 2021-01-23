    public class ProcessingQueue<T>
	{
		
		private readonly object _lock = new object();
		private readonly Queue<T> _queue = new Queue<T>();
		private readonly Action<T> _workMethod;
		private bool _pumpIsAlive;  
        private void Pump()
		{
			while (true)
			{
				
				lock (this._lock)
				{
					item = this._queue.Dequeue();
				}
				this._workMethod(item);
				lock (this._lock)
				{
					if (this._queue.Count == 0)
					{
						this._pumpIsAlive = false;
						break;
					}
				}
			}
        /// <summary>
		/// Pushes an item onto the processing the queue to be handled at an indeterminate time.
		/// </summary>
		/// <param name="item">The item to push onto the queue.</param>
		public void Push(T item)
		{
			lock (this._lock)
			{
				this._queue.Enqueue(new Containter(item));
				this.StartPump();
			}
		}
        private void StartPump()
		{
			lock (this._lock)
			{
				if (!this._pumpIsAlive)
				{
					this._pumpIsAlive= true;
					ThreadPool.QueueUserWorkItem(o => this.Pump());
				}
			}
		}

    public class MyWorker<T> : IDisposable
    {
    	private readonly Queue<T> _taskQueue; // task queue
    	private readonly object _threadLock = new object();
    	private Thread _thread; // worker thread
    	private ManualResetEvent _evExit;
    	private AutoResetEvent _evNewData;
    
    	/// <summary>Override this to process data.</summary>
    	protected abstract void ProcessData(T data);
    
    	/// <summary>Override this to set other thread priority.</summary>
    	protected virtual ThreadPriority ThreadPriority
    	{
    		get { return ThreadPriority.BelowNormal; }
    	}
    
    	protected MyWorker()
    	{
    		_taskQueue = new Queue<T>();
    		_evExit = new ManualResetEvent(false);
    		_evNewData = new AutoResetEvent(false);
    	}
    
    	~MyWorker()
    	{
    		Dispose(false);
    	}
    
    	private void ThreadProc()
    	{
    		try
    		{
    			var wh = new WaitHandle[] { _evExit, _evNewData };
    			while(true)
    			{
    				T data = default(T);
    				bool gotData = false;
    				lock(_taskQueue) // sync
    				{
    					if(_taskQueue.Count != 0) // have data?
    					{
    						data = _taskQueue.Dequeue();
    						gotData = true;
    					}
    				}
    				if(!gotData)
    				{
    					if(WaitHandle.WaitAny(wh) == 0) return; // demanded stop
    					continue; //we have data now, grab it
    				}
    				ProcessData(data);
    				if(_evExit.WaitOne(0)) return;
    			}
    		}
    		catch(ThreadInterruptedException)
    		{
    			// log warning - this is not normal
    		}
    		catch(ThreadAbortException)
    		{
    			// log warning - this is not normal
    		}
    	}
    
    	public void Start()
    	{
    		lock(_threadLock)
    		{
    			if(_thread != null)
    				throw new InvalidOperationException("Already running.");
    			_thread = new Thread(ThreadProc)
    			{
    				Name = "Worker Thread",
    				IsBackground = true,
    				Priority = ThreadPriority,
    			};
    			_thread.Start();
    		}
    	}
    
    	public void Stop()
    	{
    		lock(_threadLock)
    		{
    			if(_thread == null)
    				throw new InvalidOperationException("Is not running.");
    			_evExit.Set();
    			if(!_thread.Join(1000))
    				_thread.Abort();
    			_thread = null;
    		}
    	}
    
    	/// <summary>Enqueue data for processing.</summary>
    	public void EnqueueData(T data)
    	{
    		lock(_taskQueue)
    		{
    			_taskQueue.Enqueue(data);
    			_evNewData.Set(); // wake thread if it is sleeping
    		}
    	}
    
    	/// <summary>Clear all pending data processing requests.</summary>
    	public void ClearData()
    	{
    		lock(_taskQueue)
    		{
    			_taskQueue.Clear();
    			_evNewData.Reset();
    		}
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		lock(_threadLock)
    		{
    			if(_thread != null)
    			{
    				_evExit.Set();
    				if(!_thread.Join(1000))
    					_thread.Abort();
    				_thread = null;
    			}
    		}
    		_evExit.Close();
    		_evNewData.Close();
    		if(disposing)
    			_taskQueue.Clear();
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    }

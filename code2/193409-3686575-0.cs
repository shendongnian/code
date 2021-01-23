    public sealed class WorkQueue<T>
    {
    	private readonly System.Collections.Generic.Queue<T> _queue = new System.Collections.Generic.Queue<T>();
    	private readonly object _lock = new object();
    
    	public void Put(T item)
    	{
    		lock (_lock)
    		{
    			_queue.Enqueue(item);
    		}
    	}
    
    
    	public bool TryGet(out T[] items)
    	{
    		if (_queue.Count > 0)
    		{
    			lock (_lock)
    			{
    				if (_queue.Count > 0)
    				{
    					items = _queue.ToArray();
    					_queue.Clear();
    					return true;
    				}
    			}
    		}
    
    		items = null;
    		return false;
    	}
    }

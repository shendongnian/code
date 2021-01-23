    class MyQueue<T>
    {
    	private readonly Queue<T> queue = new Queue<T>();     
    	public event EventHandler Enqueued;     
    	protected virtual void OnEnqueued()     
    	{         
    		if (Enqueued != null) 
    		Enqueued(this, EventArgs e);     
    	}     
    	public virtual void Enqueue(T item)     
    	{         
    		queue.Enqueue(item);         
    		OnEnqueued();     
    	}     
    	public int Count 
         {
                 get 
                 { 
                         return queue.Count; 
                 }
         }
    	public virtual T Dequeue()     
    	{
    	        T item = queue.Dequeue();         
    	        OnEnqueued();
    	        return item;
            }
    } 

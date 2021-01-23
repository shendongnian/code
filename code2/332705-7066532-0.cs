    public class DispositionWrapper<T> : IDisposable
    	where T : IDisposable
    {
    	private readonly T _instance;
    	private bool _allowDisposition;
    
    	public DispositionWrapper(T instance, bool allowDisposition)
    	{
    		if (instance == null)
    		{
    			throw new ArgumentNullException("instance");
    		}
    
    		this._instance = instance;
    		this._allowDisposition = allowDisposition;
    	}
    
    	public T Instance
    	{
    		get
    		{
    			return this._instance;
    		}
    	}
    
    	public void Dispose()
    	{
    		if (this._allowDisposition)
    		{
    			this._instance.Dispose();
    		}
    	}
    }

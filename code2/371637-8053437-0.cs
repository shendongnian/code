    public abstract class ComWrapper : IDisposable
    {
    	protected internal object _comObject;
    	protected ComWrapper(object comObject)
    	{
    		_comObject = comObject;
    	}
    
    	#region " IDisposable Support "
    
    	private bool _disposed = false;
    
    	protected virtual void FreeManagedObjects()
    	{
    	}
    
    	protected virtual void FreeUnmanagedObjects()
    	{
    		ReleaseComObject(_comObject);
    	}
    
    	private void Dispose(bool disposing)
    	{
    		if (!_disposed) {
    			if (disposing) {
    				FreeManagedObjects();
    			}
    			FreeUnmanagedObjects();
    			_disposed = true;
    		}
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected override void Finalize()
    	{
    		Dispose(false);
    		base.Finalize();
    	}
    
    	#endregion
    }

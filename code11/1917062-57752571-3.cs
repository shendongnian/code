    public abstract class AlgorithmBase
    {
    	private readonly AlgorithmBase Parent;
    
    	private void RequestQueue()
    	{
    	}
    
    	public Task<float[]> GetDataAsync(int requestedItemIndex) 
             => Parent.GetDataAsync(requestedItemIndex);
    }

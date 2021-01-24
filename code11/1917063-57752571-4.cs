    public class SortAlgorithm : AlgorithmBase
    {
    	public override async Task<float[]> GetDataAsync(int requestedItemIndex)
    	{
    		// asynchronously get data 
            var data = await Parent.GetDataAsync(requestedItemIndex);
            // synchronously process data and return
            return this.ProcessData(data);
    	}
    
        private float[] ProcessData(float[] data)
        {
        }
    }

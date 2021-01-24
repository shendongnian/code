    public class DetailController
    {
    	public async Task<IList<int>> GetDetails()
    	{
    		var details = await ServiceWrapper.GetDetails();
    		return details;
    	}
    }
    
    public static class ServiceWrapper
    {
    	public static Task<IList<int>> GetDetails()
    	{
    		var tcs = new TaskCompletionSource<IList<int>>();
    		ServiceManager.DetailsAsync("param1", "param2", (IList<int> details) =>
    			{
    				tcs.SetResult(details);
    			});
    		return tcs.Task;
    	}
    }

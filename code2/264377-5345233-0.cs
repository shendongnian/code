    public class WebServiceClient
    {
    	public int[] GetXData(int intVar)
    	{
    		return new int[] { intVar, intVar };
    	}
    }
    
    public class BoardcastingWebServiceCleint
    {
    	public int[] BroadcastQuery(Func<WebServiceClient, int[]> webServiceCall)
    	{
    		List<WebServiceClient> clients = new List<WebServiceClient>();
    		List<int> allResults = new List<int>();
    		foreach (WebServiceClient client in clients)
    		{
    			int[] result = webServiceCall.Invoke(client);
    			allResults.AddRange(result);
    		}
    
    		return allResults.ToArray();
    	}
    }
    
    static void Main(string[] args)
    {
    	BoardcastingWebServiceCleint bwsc = new BoardcastingWebServiceCleint();
    	bwsc.BroadcastQuery((client) => { return client.GetXData(5); });
    }

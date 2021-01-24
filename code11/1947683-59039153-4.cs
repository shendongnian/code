    public class FooApiClient: IFooApiClient
    {
    	private readonly IWebRequestWrapper _webRequestWrapper;
    	public FooApiClient(IWebRequestWrapper webRequestWrapper) =>
    		_webRequestWrapper = webRequestWrapper ?? throw new ArgumentNullException();
    	public FooBaseData GetBaseData(string id) =>	
    		_webRequestWrapper.DoRequest(id, response => new FooBaseData...);
    	public FooAdvancedData GetAdvancedData(string id) =>	
    		_webRequestWrapper.DoRequest(id, response => new FooAdvancedData...);
    }

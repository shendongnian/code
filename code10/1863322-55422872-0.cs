    async Task Main()
    {
    	var result = await GetById("");
    	if(result == null)
    		Console.WriteLine("OK!");
    	else
    		throw new Exception("Expected Null!");
    	
    }
    
    public IObservable<object> GetById(string id)
    {
    	var o = Observable.Create<object>(obs =>
    	{
    		obs.OnNext(null);
    		obs.OnCompleted();
    		return Disposable.Empty;
    	});
    
    	return o;
    }

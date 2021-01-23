    public object Execute(TRequest request)
    {
    	try
    	{
    		//Run the request in a managed scope serializing all 
    		return Run(request);
    	}
    	catch (Exception ex)
    	{
    		return HandleException(request, ex);
    	}
    }
    
    protected object HandleException(TRequest request, Exception ex)
    {
    	var responseStatus = ResponseStatusTranslator.Instance.Parse(ex);
    
    	if (EndpointHost.UserConfig.DebugMode)
    	{
    		// View stack trace in tests and on the client
    		responseStatus.StackTrace = GetRequestErrorBody() + ex;
    	}
    
    	Log.Error("ServiceBase<TRequest>::Service Exception", ex);
    
    	//If Redis is configured, maintain rolling service error logs in Redis (an in-memory datastore)
    	var redisManager = TryResolve<IRedisClientsManager>();
    	if (redisManager != null)
    	{
    		try
    		{
    			//Get a thread-safe redis client from the client manager pool
    			using (var client = redisManager.GetClient())
    			{
    				//Get a client with a native interface for storing 'ResponseStatus' objects
    				var redis = client.GetTypedClient<ResponseStatus>();
    
    				//Store the errors in predictable Redis-named lists i.e. 
    				//'urn:ServiceErrors:{ServiceName}' and 'urn:ServiceErrors:All' 
    				var redisSeriviceErrorList = redis.Lists[UrnId.Create(UrnServiceErrorType, ServiceName)];
    				var redisCombinedErrorList = redis.Lists[UrnId.Create(UrnServiceErrorType, CombinedServiceLogId)];
    
    				//Append the error at the start of the service-specific and combined error logs.
    				redisSeriviceErrorList.Prepend(responseStatus);
    				redisCombinedErrorList.Prepend(responseStatus);
    
    				//Clip old error logs from the managed logs
    				const int rollingErrorCount = 1000;
    				redisSeriviceErrorList.Trim(0, rollingErrorCount);
    				redisCombinedErrorList.Trim(0, rollingErrorCount);
    			}
    		}
    		catch (Exception suppressRedisException)
    		{
    			Log.Error("Could not append exception to redis service error logs", suppressRedisException);
    		}
    	}
    
    	var responseDto = CreateResponseDto(request, responseStatus);
    
    	if (responseDto == null)
    	{
    		throw ex;
    	}
    
    	return new HttpResult(responseDto, null, HttpStatusCode.InternalServerError);
    }

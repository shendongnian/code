    public class Controller : ApiController
    {
    
    		static string _sessionToken = "";
            static string SessionToken
    		{
    			get
    			{
    				if (string.IsNullOrEmpty(_sessionToken))
    				{
    					InitToken();
    				}
                    return _sessionToken
    			}
    		}		
    		
    		void InitToken()
    		{
    		if (string.IsNullOrEmpty(_sessionToken))
                    {
                        // This registers my service. 
                        var registerConector = ConectorOSCCApi.RegisterConector();
    
                        if (respostaRegistrarConector.ErrorCode != NO_ERROR)
                        {
                            throw new Exception();
                        }
    
                        _sessionToken = registerConector.SessionToken;
                    }
    		}
			
			public Controller() : base()
			{
				InitToken();
				// anything else
			}
    		
    
            [HttpPost]
            [Route("connector/webhook")]
            public async Task<HttpStatusCode> Webhook(UpdateContentRequestBody body)
            {
                var NO_ERROR = 0;
    
                try
                {
                    ConectorApi.KeepAliveRequest(SessionToken);
                    RepeatKeepAlive();
    
                    ProccessDataAndSendResponseRequest(body);
    
                    return HttpStatusCode.OK;
                }
    
                catch (Exception e)
                {
                    SessionToken = "";
                    return HttpStatusCode.InternalServerError;
                }
    		}
    }

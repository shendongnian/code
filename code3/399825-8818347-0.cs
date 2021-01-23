	private List<T> Get<T>(Func<TmsServiceClient, List<T>> clientCall)
	{
	    List<T> results = new List<T>();
		using (TmsServiceClient client = new TmsServiceClient())
        {
            try
            {
				// invoke client method passed as method parameter
                results = clientCall(client);
            }
            catch (FaultException<TMSCustomException> myFault)
            {
                Console.WriteLine(myFault.Detail.ExceptionMessage);
                client.Abort();                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Abort();                   
            }
        }
        return results;
	}
	

    public static class WebServiceFactory
    {
    	public static MyWebService GetMyWebService()
    	{
    		MyWebService clientProxy = new MyWebService();
    		clientProxy.Url = ConfigurationSettings.AppSettings["webServiceUrl"];
    		return clientProxy;
    	}
    }

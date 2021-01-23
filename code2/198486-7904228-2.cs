    public ActionResult EtradeAuthorize()
    {
    
        var consumer = new WebConsumer(ETradeConsumer.CreateServiceDescription(), TokenManager);
        var accessToken = "";
        consumer.Channel.Send(consumer.PrepareRequestUserAuthorization(null, null, null));
    	var accessTokenResponse = consumer.ProcessUserAuthorization();
    	    
        if (accessTokenResponse != null)
    	{
    	    accessToken = accessTokenResponse.AccessToken;
    	}
    	else
    	{
    	    RedirectToAction("EtradeAuthorize", "MyController");
    	}
    
        return RedirectToAction("SyncStatus", accessToken); //everything went well
    }

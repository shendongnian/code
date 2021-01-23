        var consumer = ETradeConsumer.CreateConsumer(TokenManager);
	string requestToken;
	Uri popupWindow = ETradeConsumer.PrepareRequestAuthorization(consumer, out requestToken);
	var etradeViewModel = new ETradeAuthorizeViewModel(popupWindow, requestToken);
	return View(etradeViewModel);
    }
    [HttpPost]
    public ActionResult CompleteAuthorization(FormCollection formCollection)
    {
	string accessToken = "";
	var consumer = ETradeConsumer.CreateConsumer(TokenManager);
	var authorizationReponse = ETradeConsumer.CompleteAuthorization(consumer, formCollection["requestToken"], formCollection["userCode"]);
	if (authorizationReponse != null)
	{
  	    accessToken = authorizationReponse.AccessToken;
	}
	var etradeViewModel = new ETradeCompleteAuthorizeViewModel(formCollection["requestToken"], formCollection["userCode"], accessToken);
	return View(etradeViewModel);
    }

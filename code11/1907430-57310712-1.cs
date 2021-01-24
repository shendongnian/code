    [HttpPost()]
    public async Task<IActionResult> CreatedAsync([FromBody]DataWrapper dataWrapper)
    {
        int timeOut = 0;
        BusinessComponet.CollectData(dataWrapper);
        // Wait for the event handler to fire, with a timeout so it doesn't wait forever
        while (_result == null && timeOut < 20000){
            Thread.Sleep(1000);
            timeOut += 1000;
        }
        return _result;
    }
    
    private static IHttpResponse _result = null;
    static void BusinessComponentDeliverResponse(object sender, DeliverEventArgs e)
    {
        if(e.IsValid)
            _result = Ok("received");  
        else
            _result = BadRequest(e.ErrorMessage); 
    }

    [HttpPost()]
    public async Task<IActionResult> CreatedAsync([FromBody]DataWrapper dataWrapper)
    {
        int timeOut = 0;
        BusinessComponet.CollectData(dataWrapper);
        while (_result == null && timeOut < 20000){
            Thread.Sleep(1000);
            timeOut += 1000;
        }
        return _result; // How to do this in real?
    }
    
    private static IHttpResponse _result = null;
    static void BusinessComponentDeliverResponse(object sender, DeliverEventArgs e)
    {
        if(e.IsValid)
            _result = Ok("received");  // How to use this as return for the controller?
        else
            _result = BadRequest(e.ErrorMessage); // How to use this as return for the controller?
    }

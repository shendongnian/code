    public async Task<ActionResult> Index()
    {
        //The Connected Client 'manages' this token. 
        //HttpContext.Response.ClientDisconnectedToken.IsCancellationRequested will be set to true if the client disconnects
        try
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var url = "http://google.com";
                var html = await client.GetAsync(url,  HttpContext.Response.ClientDisconnectedToken);
            }
        }
        catch (TaskCanceledException e)
        {
            //The Client has gone
            //you can handle this and the request will keep on being processed, but no one is there to see the resonse
        }
        return View();
    }

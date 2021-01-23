    [AsyncTimeout(500)] //500ms
    public async Task<ActionResult> Index(CancellationToken cancel)
    {
        //ASP.Net manages the cancel token.
        //cancel.IsCancellationRequested will be set to true after 500ms
        try
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var url = "http://google.com";
                var html = await client.GetAsync(url, cancel);
            }
        }
        catch (TaskCanceledException e)
        {
            //ASP.Net has killed the request
            //Yellow Screen Of Death with System.TimeoutException
            //the return View() below wont render
        }
        return View();
    }

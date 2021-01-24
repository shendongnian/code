    [TestMethod()]
    public void PostTest()
    {
        var controller = new API_FIRM_LINKController();
        IHttpActionResult expectedResult = ...
        
        // call PostAsync and wait for it to finish
        Task taskPost =  Task.Run(() => controller.PostAsync(API_FIRM_LINK, aPI_FIRM_LINK));
        taskPost.Wait();
        IHttpActionResult result = taskPost.Result;
        // TODO: compare result with expected result
    }

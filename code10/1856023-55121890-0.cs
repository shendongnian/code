    [TestMethod()]
    public async Task PostTestAsync()
    {
        var controller = new API_FIRM_LINKController();
        // TODO: do some preparations, so you can expect a specific return value
        IHttpActionResult expectedResult = ...
        
        // call PostAsync and await for it to finish
        Task taskPost =  controller.PostAsync(API_FIRM_LINK, aPI_FIRM_LINK);
        IHttpActionResult result = await taskPost;
        // of course this can be done in one line:
        IHttpActionResult result = await controller.PostAsync(API_FIRM_LINK, aPI_FIRM_LINK);
        // compare whether result equals expectedResult
        // for example: create a class that implements IComparer<IHttpActionResult>
        IComparer<IHttpActionResult> comparer = new IHttpActionResultComparer();
        Assert.IsTrue(comparer.Equals(expectedResult, result);
    }

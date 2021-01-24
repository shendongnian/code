[TestMethod]
    public void GetAll_ShouldReturnAllCli()
    {
        var contrller = new CliController();
        var result = contrller.GetAllCli() as JsonResult;
        var Originalresult = JsonHelper.GetJsonObjectRepresentation<IDictionary<string, object>>(result);
        Assert.AreEqual(5, Originalresult.count());
    }

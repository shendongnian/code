    [TestMethod]
    public void ControllerMethod_WhenMethodCalled_ThenSomeRecordsAreReturned()
    {
        // arrange
		var records = new List<string> { "Record1", "Record2" };
        var expectedRecordCount = records.Count();
        myService.Setup(x => x.GetRecordsFromDatabase()).Returns(records);
        // act
        var result = myController.GetRecords(); //Assuming this controller method returns JsonDotNetResult
        // assert
        var jsonResult = result.GetDataFromJsonResult<JsonDotNetResult, IEnumerable<string>>();
        Assert.AreEqual(expectedRecordCount, jsonResult.Count());
    }

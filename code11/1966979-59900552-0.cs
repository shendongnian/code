    [TestMethod()]
    public void GlobalSeach_PutTest()
    {
        SearchHistory history = new SearchHistory {
            // redacted for ease of reading on SO
        }
        
        // _dashboardreposMock is an example of Mock<IDashboardRepository>
        _dashboardreposMock.Setup(_ => _.SaveSearchHistoryByUser(It.IsAny<SearchHistory>)).Returns(1);
        var controller = new GlobalSearchController(_config);
        int response = controller.Post(history);
        Assert.IsTrue(response == 1);
    }

    [TestMethod]
    public void SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrdersTest() {
        //Arrange
        var options = new DbContextOptionsBuilder<DAL_EFCore.AdventureWorks2017Context>()
            .UseInMemoryDatabase(databaseName: "SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrdersTest")
            .Options;
            
        using (var context = new DAL_EFCore.AdventureWorks2017Context(options)) {
            InsertData(options);
        }
        
        using (var context = new DAL_EFCore.AdventureWorks2017Context(options)) {
            //actual EFCoreTaskProvider.Tasks targeting in-memory database
            var taskProvider = new EFCoreTaskProvider.Tasks(context);
            //mock factory configured to return the desired provider
            var mockFactory = Mock.Of<ITaskProviderFactory>(_ =>
                _.GetTaskProvider() == taskProvider //return the actual provider for testing
            );
            // actual CoreReportService.DataReports (Subject under test)
            var dataReports = DataReports(mockFactory);
            
            //Act
            var result = dataReports.SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrders().ToList();
            
            //Assert
            Assert.IsTrue(result.Count == 1);
        }
    }
    

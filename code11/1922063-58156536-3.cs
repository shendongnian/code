        [TestMethod]
        public void TestProccessFunctionCallHelperGetData()
        {
             Mock<IHelper> mockHelper = new Mock<IHelper>();
             Mock<IDataProvider> mockDatabaseProvider = new Mock<IDataProvider();
        
             mockHelper.Setup(m => m.getData(It.IsAny<string>())).Returns(new DataTable());
             MyApp app = new MyApp(mockDatabaseProvider.Object, mockHelper.Setup);
             app.Process();
             Assert.AreEquals(mockHelper.numTimesCalled, 1);
        }
        
        [TestMethod]
        public void TestHelperGetData()
        {
            var query = ""; //TODO: write dummy query
            var dataTableToReturn = new DataTable(); //TODO: add some data
            Mock<IDataProvider> mockDatabaseProvider = new Mock<IDataProvider();
            mockDatabaseProvider.Setup(m => m.CreateConnection(It.IsAny<string>())).Returns(new SqlConnection("dummy connection string"));
            mockDatabaseProvider.Setup(m => m.FillDatatableFromAdapter(It.IsAny<IDbCommand>())).Returns(dataTableToReturn );
        
            IHelper h = new Helper(mockDatabaseProvider.Object);
            var actualDataTable = h.getData(query);
            Assert.AreEqual(dataTableToReturn, actualDataTable  );
        
        }
        
        [TestMethod]
        public void TestDataProviderFillDataTableFromAdapter()
        {
           //This test seems to me more like integration test because you need to mock a db or use a real db 
        }
        
        [TestMethod]
        public void TestYourData()
        {
           // Create a dataTable with data so you can continue with your testing
        }

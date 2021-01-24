    [TestMethod]
    [DataSource("System.Data.SqlClient",
                @"Data Source=****;Initial Catalog=****;Persist Security Info=True;User ID=sa;Password=****;Pooling=False",
                "Query",
                DataAccessMethod.Sequential)] 
    public void MyTestMethod()
    {
               // my testing here using TestContext.DataRow["columnName"] to get the Name, id, Parameters...
    }

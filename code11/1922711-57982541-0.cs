    [TestMethod]
    public void UnitTestCase
    {
        Mock<IDataAccess> mock = 
        Mock<IDataAccess>();
        List<string> data1 = new List<string>();
        mock.Setup(x =>  
        x.GetDataToList(It.Is<string(
        s => s.Contains("select * from table ")))).Returns(data1); <======= (here)
        List<string> data2 = new List<string>();
        mock.Setup(x =>  
        x.GetDataToList(It.Is<string(
        s => s.Contains("select * from table1")))).Returns(data2);
    }

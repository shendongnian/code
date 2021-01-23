    /// <summary>
    /// Tests if a moq can send an exception with argument checking
    ///</summary>
    [TestMethod]
    public void TestException()
    {
        Mock<IMath> mock = new Mock<IMath>();
        mock.Setup(m => m.AddNumbersBetween(It.IsAny<int>(), It.IsAny<int>()));
        mock.Setup(foo => foo.AddNumbersBetween(It.IsAny<int>(), It.IsAny<int>()))
            .Callback<int, int>((i, j) => CheckArgs(i, j));
            
        try
        {
            mock.Object.AddNumbersBetween(1, 2);
        }
        catch (Exception ex)
        {
            // Will not enter
            Console.WriteLine("Exception raised: {0}", ex);
        }
        try
        {
            mock.Object.AddNumbersBetween(2, 1);
        }
        catch (Exception ex)
        {
            // Will enter here, exception raised
            Console.WriteLine("Exception raised: {0}", ex);
        }
    }
    private bool CheckArgs(int i, int j)
    {
        if( i > j)
            throw new ArgumentException();
        return true;
    }

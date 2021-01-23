    [TestMethod]
    public void MyTest()
    {
      GeneralThreadAffineContext.Run(() =>
      {
        var viewModel = new MyViewModel();
        viewModel.Run();
        //Assert something here
      });
    }

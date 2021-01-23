    [TestMethod]
    public void MyTest()
    {
      MyViewModel viewModel = null;
      GeneralThreadAffineContext.Run(() =>
      {
        viewModel = new MyViewModel();
        viewModel.Run();
      });
      //Assert something here
    }

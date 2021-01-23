    List names = new List {"Test", "Test1"};
    DynamicMock mockView = new DynamicMock(typeof(IView));
    mockView.ExpectAndReturn("get_Names", names);
    IView view = (IView)mockView.MockInstance;
    Assert.AreEqual(names, presenter.GetNames(view));

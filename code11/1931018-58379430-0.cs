    [Test]
    public void TestOne()
    {
        var mocks = new MockRepository();
        var mockView = mocks.CreateMock<IToTestView>();
        ToTestPresenter presenter = new ToTestPresenter(mockView);
        using (mocks.Ordered())
        {
             mockView.Property1 = FilterOptions.OptionA;
             mockView.Property2 = OtherFilterOptions.DefaultFilterOptions();
             LastCall.Constraints(
                 Property.Value("Filter1", true)
                 & Property.Value("Filter2", false));
        }
        mocks.ReplayAll();
        presenter.InitialiseView();
        mocks.VerifyAll();
    }

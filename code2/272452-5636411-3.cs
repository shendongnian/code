    var mockedDatatable= GetMockdt();
    var mocks = new MockRepository();
    var dal = mocks.StrictMock<DataAccess>();
    using (mocks.Record())
    {
      Expect.Call(dal.GetDataTableFromDatabase("", null)).Return(mockedDatatable).IgnoreArguments();
    }
    using (mocks.Playback())
    {
      new SomeClass(dal);
    }

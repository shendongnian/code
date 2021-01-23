    MockRepository mocks = new MockRepository(); 
    IMyINterface interface = mocks.CreateMock<IMyINterface>(); 
  
    using (mocks.Record()) 
    { 
       Expect.Call(interface.GetMeSomeIngeter()).Return(5); 
    } 

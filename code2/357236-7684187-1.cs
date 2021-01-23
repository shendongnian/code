    MockRepository mocks = new MockRepository(); 
    IMyINterface interface = mocks.CreateMock<IMyINterface>(); 
  
    using (mocks.Record()) 
    { 
       Expect.Call(interface.GetMeAToy("Gizmo")).Return(new Toy() {ToyName = "Gizmo", Code = "0989"}); 
    } 

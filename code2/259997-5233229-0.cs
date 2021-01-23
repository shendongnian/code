    public MyStub()
     {
       MockRepository = new MockRepository ();
       //MyService = MockRepository.Stub<IMyService >(); //Stupid Stupid Stupid !!!
       MyService = MockRepository.GenerateStub<IMyService >();
    
       //And now, let's try to mock the behaviour
       MyService.Stub(sm => sm.GetServerState())
                    .IgnoreArguments()
                    .Do((DelegateVoid)GetServerStateCompletedBehaviour);
     }

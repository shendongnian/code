    class Generator
    {
        private readonly StateMachine state;
        public Generator()
        {
            state = new StateMachine(State.Stopped);
            // your definition of states ...
            state.Configure(State.GenerateMachineData)
            .OnEntry(() => { Generate(); })
            .Permit(Trigger.Failed, State.Error)
            .Permit(Trigger.Succeed, State.Finished);
           
            // ...
        }
        public void Succeed()
        {
            state.Fire(Trigger.Succeed);
        }
        public void Fail()
        {
            state.Fire(Trigger.Fail);
        }
        public void Generate()
        {
            // ...         
        }
    }

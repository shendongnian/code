    class StateMachineConfiguration
    {
        public IEnumerable<State> States { get; private set; }
        public IEnumerable<Trigger> Triggers { get; private set; }
    }
    class StateMachine
    {
        public StateMachine(StateMachineConfiguration config) 
        {
             if(config == null)
                  throw new ArgumentNullException();
    
             this.Configure(config.States);
             this.Allow(config.Triggers);
        }
    }

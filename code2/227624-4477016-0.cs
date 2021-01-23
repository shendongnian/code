    public CompositeAction : IAction
    {
        private ActiondCollection Action;
        
        void Add(Action action)
        {
           Action.Add(action);
        }
        
        void Execute()
        {
           foreach(Action action in Actions)
           { 
              action.Execute(); 
           }
        }
    }

    public abstract SystemAction
    {
        public SystemAction nextAction { get; set; }
        public void Execute()
        {
            this.ExecuteAction();
            if (this.nextAction != null)
                this.nextAction.Execute();
        }
        protected abstract void ExecuteAction();
        public SystemAction ThenDo(SystemAction action) 
        { 
            this.nextAction = action;
            return this.nextAction;
        }            
    }

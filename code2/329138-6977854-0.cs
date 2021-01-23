    // Context
        public class WorkItemProcessor
        {
            public IState CurrentState { get; set; }
    
            public WorkItemProcessor(IState initialState)
            {
                CurrentState = initialState;
            }
    
            public void Process(WorkItem workItem)
            {
                CurrentState.Handle(this, workItem);
            }
        }
	

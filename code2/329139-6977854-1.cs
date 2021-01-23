    // State Contract
        public interface IState
        {
            void Handle(WorkItemProcessor processor, WorkItem item);
        }
    
        // State One
        public class CompleteState : IState
        {
            public void Handle(WorkItemProcessor processor, WorkItem item)
            {
                processor.CurrentState = item.CompletenessConditionHoldsTrue ? (IState) this : new CancelState();
            }
        }
    
        // State Two
        public class CancelState : IState
        {
            public void Handle(WorkItemProcessor processor, WorkItem item)
            {
                processor.CurrentState = item.CancelConditionHoldsTrue ? (IState) this : new CompleteState();
            }
        }
	

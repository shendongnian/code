        private Dictionary<int, Action> fsm;
        public FiniteStateMachine()
        {
            this.fsm = new Dictionary<int, Action>() {
            { (int)States.Submitted, SubmittedForReview },
                {(int)States.Reviewed, Reviewing },
                {(int)States.Approved, Approving}
                };
        }
        public void ProcessEvent(Events theEvent)
        {
            var action = fsm[(int)theEvent];
            action.Invoke();
        }

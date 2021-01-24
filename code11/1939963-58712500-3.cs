        public void OnStateElection(ElectStateContext context)
        {
            switch (context.CandidateState)
            {
                case EnqueuedState enqueued when enqueued.Reason == "Triggered by recurring job scheduler":
                    Trace.WriteLine($"Was triggered by job scheduler.");
                    // Skip all jobs of job scheduler
                    context.CandidateState = new SucceededState(null, 0, 0);
                    break;
            }
        }

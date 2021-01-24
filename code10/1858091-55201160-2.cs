    public Process()
	{
		CurrentState = ProcessState.Submitted;
		transitions = new Dictionary<StateTransition, ProcessState>
		{
            //This does nothing.  Submitted -> Submitted
		    { new StateTransition(ProcessState.Submitted, Command.Submit), ProcessState.Submitted },
            //Submitted -> Reviewed
		    { new StateTransition(ProcessState.Submitted, Command.Review), ProcessState.Reviewed },
            //Reviewed -> Submitted.  Do you want this?
		    { new StateTransition(ProcessState.Reviewed, Command.Submit), ProcessState.Submitted },
            //I added this.  Reviewed -> Approved
		    { new StateTransition(ProcessState.Reviewed, Command.Approve), ProcessState.Approved }
		};
	}

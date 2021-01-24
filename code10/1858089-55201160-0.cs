    public Process()
	{
		CurrentState = ProcessState.Submitted;
		transitions = new Dictionary<StateTransition, ProcessState>
		{
		    { new StateTransition(ProcessState.Submitted, Command.Submit), ProcessState.Submitted },
		    { new StateTransition(ProcessState.Submitted, Command.Review), ProcessState.Reviewed },
		    { new StateTransition(ProcessState.Reviewed, Command.Submit), ProcessState.Submitted },
            //I added this
		    { new StateTransition(ProcessState.Reviewed, Command.Approve), ProcessState.Approved }
		};
	}

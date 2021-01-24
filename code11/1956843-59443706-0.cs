    interface IReadOnlyStatus
    {
    	MachineState State { get; }
    }
    
    interface IStatus : IReadOnlyStatus
    {
    	void RequestToUpdate(MachineState state);
    }
    
    public class Status : IStatus
    {
    	MachineState State { get; private set; }
    	void RequestToUpdate(MachineState state)
    	{
    		bool validTimeToChange = FunctionNotDefinedHere(state);
    		if (validTimeToChange) this.State = state;
    	}
    }

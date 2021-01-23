class StateManager
{
    public bool IsCorrupted
    {
        get;
        set;
    }
    public void Execute(Action body, Func<bool> fixState)
    {
        if (this.IsCorrupted)
        {
            // use some Exception-derived class here.
            throw new Exception("Cannot execute action on a corrupted object.");
        }
        try
        {
            body();
        }
        catch (Exception)
        {
            this.IsCorrupted = true;
            if (fixState())
            {
                this.IsCorrupted = false;
            }
            throw;
        }
    }
}
public class ExampleUsage
{
    private readonly object ExampleLock = new object();
    private readonly StateManager stateManager = new StateManager();
    public void ExecuteLockedMethod()
    {
        lock (ExampleLock)
        {
            stateManager.Execute(ExecuteMethod, EnsureValidState);
        }
    }
    private void ExecuteMethod()
    {
        //does something, maybe throws an exception
    }
    public bool EnsureValidState()
    {
        // code to make sure the state is valid
        // if there is an exception returns false,
        return true;
    }
}

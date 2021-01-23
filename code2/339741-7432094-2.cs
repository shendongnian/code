    public class DeterministicState: IDisposable
    {
     private Memento Before { get; set; }
     public DeterministicState(Stateful stateful, object related)
     {
    	Before = stateful.GetMementoAndApplyState(related); // generate memento before applying
     }
    
     public void Dispose()
     {
    	Before.Restore();
     }
    }

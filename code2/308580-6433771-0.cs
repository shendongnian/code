    public class SampleClass
    {
        [Import]
        private Manager manager; //Setting it to null is redundant.
    }
    
    
    [Export]
    public class Manager
    {
    }

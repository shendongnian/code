    public class SampleClass
    {
        [Import]
        private IManager Manager;
    }
    
    [InheritedExport]
    public interface IManager { }
    
    public class Manager : IManager { }

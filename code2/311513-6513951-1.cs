    public interface ITestAction : INotifyPropertyChanged {
        int Id { get; }
        ITestBase Owner { get; }
        ITestActionGroup Parent { get; }
    
        ITestAction CopyToNewOwner(ITestBase newOwner);
        void MoveToNewOwner(ITestBase newOwner); }

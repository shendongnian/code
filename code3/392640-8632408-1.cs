    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            // ...

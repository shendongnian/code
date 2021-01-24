    public class MoveCustomerCommand : ICommand
        {
            public int CustomerId { get; set; }
    
            public bool CanExecute(object parameter) => true;
    
            public void Execute(object parameter) { }
    
    
            public event EventHandler CanExecuteChanged;
        }
    
    public class KillCustomerCommand : ICommand
        {
            public int CustomerId { get; set; }
    
            public bool CanExecute(object parameter) => true;
    
            public void Execute(object parameter) { }
    
    
            public event EventHandler CanExecuteChanged;
        }

    class MyCommand : ICommand
    {
        // Singleton for the simple cases, may be replaced with your own factory     
        public static ICommand Instance { get; } = new MyCommand();
        public bool CanExecute(object parameter)
        {
              return true; 
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
             System.Windows.Application.Current.Shutdown();    
        }   
}

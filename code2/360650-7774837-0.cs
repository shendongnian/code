    // MyView.cs
    public class MyView : UserControl
    { 
        public MyViewViewModel ViewModel 
        { 
            get { return (MyViewViewModel) DataContext;}
            set { DataContext = value; }
        }
    }
    // DelegateCommand.cs
    public class DelegateCommand : ICommand
    {
          private readonly Predicate<object> _canExecute;
          private readonly Action<object> _execute;
          public DelegateCommand(Action<object> execute)
               : this(execute, null) {}
          public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
          {
               _execute = execute;
               _canExecute = canExecute;
          }
          public override bool CanExecute(object parameter)
          {
              if (_canExecute == null)
              {
                return true;
              }
              return _canExecute(parameter);
          }
          public override void Execute(object parameter)
          {
            _execute(parameter);
          }     
     }
     // MyViewViewModel.cs
     public class MyViewViewModel 
     {
        public ICommand AddCommand {get;set;}
        public MyViewViewModel()
        {
              AddCommand = new DelegateCommand (AddCommandMethod, AddCommandMethodCanExecute);
        }
        private void AddCommandMethod (object parameter)
        {
        }
        private bool AddCommandMethodCanExecute(object parameter)
        {
             // Logic here
             return true;
        }
     }
     // MyView.xaml
     <Button Command="{Binding AddCommand}" />

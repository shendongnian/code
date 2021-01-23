    public class RelayCommand:ICommand
    {
       private bool _isEnabled;
       public bool IsEnabled
       {
           get { return _isEnabled; }
           set
           {
               if (value != _isEnabled)
               {
                   _isEnabled = value;
                   if (CanExecuteChanged != null)
                   {
                       CanExecuteChanged(this, EventArgs.Empty);
                   }
               }
           }
       }
       private Action _handler;
       public RelayCommand(Action handler)
       {
           _handler = handler;
       }
       
       public bool CanExecute(object parameter)
       {
           return IsEnabled;
       }
       public event EventHandler CanExecuteChanged;
       public void Execute(object parameter)
       {
           _handler();
       }
    }

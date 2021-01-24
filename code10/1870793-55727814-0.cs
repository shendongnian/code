public class RelayCommand : ICommand
{
    private Predicate<object> _canExecute;
    private Action<object> _execute;
    public RelayCommand(Predicate<object> canExecute, Action<object> execute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    public bool CanExecute(object parameter)
    {
        return _canExecute(parameter);
    }
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}
Then, you would add the `RelayCommand` as a property to your view model such as like this:
public class ViewModel : ViewModelBase
{
    private RelayCommand colorCmd;
    public ICommand ColorCmd
    {
        get
        {
            colorCmd ?? colorCmd = new RelayCommand(p => ColorCmdCanExecute(), p => ColorCmdExectued());
            return colorCmd;
        }
    }
    private bool ColorCmdCanExecute()
    {
        //CanExecute code here
        ...
    }
    private void ColorCmdExecuted()
    {
        //Command execute code here
        ...
    }
}
For more information on MVVM and `ICommand` implementation, there are lots of resources. [This one](https://intellitect.com/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/) is pretty easy to understand for a WPF beginner and should give you a bit more insight on how to proceed.

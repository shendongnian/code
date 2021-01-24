csharp
public sealed class MyViewModel: INotifyPropertyChanged
{
    public bool ShowSuccess 
    {
        get { return _success; } 
        set 
        { 
            _success = value; 
            PropertyChanged?.Invoke( ... );
        } 
    }
    public ICommand TestCommand 
	{
		get
		{
			_test = _test ?? new DelegateCommand(()=> ShowSuccess = true);
			return _test;
		}
    }
}
public class DelegateCommand : ICommand
{
    private readonly Predicate<object> _canExecute;
    private readonly Action<object> _execute;
 
    public event EventHandler CanExecuteChanged;
 
    public DelegateCommand(Action<object> execute) 
                   : this(execute, null)
    {
    }
 
    public DelegateCommand(Action<object> execute, 
                   Predicate<object> canExecute)
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
 
    public void RaiseCanExecuteChanged()
    {
        if( CanExecuteChanged != null )
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}

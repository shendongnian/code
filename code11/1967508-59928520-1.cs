csharp
public sealed class MyViewModel : INotifyPropertyChanged
{
	private ICommand _test;
	private bool _success;
	public bool ShowSuccess
	{
		get { return _success; }
		set
		{
			_success = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowSuccess)));
		}
	}
	public ICommand TestCommand
	{
		get
		{
			_test = _test ?? new DelegateCommand((arg) => ShowSuccess = true);
			return _test;
		}
	}
	public event PropertyChangedEventHandler PropertyChanged;
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
	public bool CanExecute(object parameter)
	{
		if (_canExecute == null)
		{
			return true;
		}
		return _canExecute(parameter);
	}
	public void Execute(object parameter)
	{
		_execute(parameter);
	}
	public void RaiseCanExecuteChanged()
	{
		CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}

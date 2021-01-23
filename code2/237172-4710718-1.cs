    public class ButtonProxyCommand : ICommand
	{
		public bool CanExecute(object parameter)
		{
			var btn = parameter as ButtonBase;
 
			if (btn == null || btn.Command == null)
				return false;
 
			return btn.Command.CanExecute(btn.CommandParameter);
		}
 
		public event EventHandler CanExecuteChanged;
 
		public void Execute(object parameter)
		{
			if (parameter == null)
				return;
 
			var btn = parameter as ButtonBase;
 
			if (btn == null || btn.Command == null)
				return;
 
			Action a = () => btn.Focus();
			var op = Dispatcher.CurrentDispatcher.BeginInvoke(a);
 
			op.Wait();
			btn.Command.Execute(btn.CommandParameter);
		}
 
		private static ButtonProxyCommand _instance = null;
		public static ButtonProxyCommand Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ButtonProxyCommand();
 
				return _instance;
			}
		}
	}

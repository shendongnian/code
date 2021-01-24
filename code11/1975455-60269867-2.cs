	using System;
	using System.Windows.Input;
	namespace SO60269403
	{
		public abstract class ACommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			public virtual bool CanExecute(object parameter) => true;
			public abstract void Execute(object parameter);
		}
	}

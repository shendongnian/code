    public class BindableButton : Button
	{
		public BindableButton()
		{
			Click += (sender, e) =>
				{
					if (Command != null && Command.CanExecute(CommandParameter))
						Command.Execute(CommandParameter);
				};
		}
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
		public static DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(ICommand), typeof(BindableButton), new PropertyMetadata(null, CommandChanged));
		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}
		public static DependencyProperty CommandParameterProperty =
			DependencyProperty.Register("CommandParameter", typeof(object), typeof(BindableButton), new PropertyMetadata(null));
		private static void CommandChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			BindableButton button = source as BindableButton;
			button.RegisterCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
		}
		private void RegisterCommand(ICommand oldCommand, ICommand newCommand)
		{
			if (oldCommand != null)
				oldCommand.CanExecuteChanged -= HandleCanExecuteChanged;
			if (newCommand != null)
				newCommand.CanExecuteChanged += HandleCanExecuteChanged;
			HandleCanExecuteChanged(newCommand, EventArgs.Empty);
		}
		// Disable button if the command cannot execute
		private void HandleCanExecuteChanged(object sender, EventArgs e)
		{
			if (Command != null)
				IsEnabled = Command.CanExecute(CommandParameter);
		}
	}

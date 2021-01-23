		private static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			ICommand command = (ICommand)control.GetValue(CommandProperty);
			object commandParameter = control.GetValue(CommandParameterProperty);
			if (sender is TreeViewItem)
			{
				if (!((TreeViewItem)sender).IsSelected)
					return;
			}
			if (command.CanExecute(commandParameter))
			{
				command.Execute(commandParameter);
			}
		}

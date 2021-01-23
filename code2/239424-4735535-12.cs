    	public static ICommand RoutedClickCommand = new RoutedUICommand("ClickCommand", "ClickCommand", typeof(MainWindow));
		private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}
		private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			MessageBox.Show("ololo");
		}

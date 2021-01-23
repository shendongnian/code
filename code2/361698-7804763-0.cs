	cbo1.Dispatcher.BeginInvoke(
		(Action)(() => StyleComboBoxItem(cbo1)), 
		System.Windows.Threading.DispatcherPriority.Background);
	
	cbo1.Dispatcher.BeginInvoke(
		(Action)(() =>
		{
			//code to style the comboboxitem;
		}),
		System.Windows.Threading.DispatcherPriority.Background);

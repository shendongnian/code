		private void OnArrayDataGridInitialized(object sender, EventArgs e)
		{
			var valueGrid = (DataGrid)sender;
			var parameterVm = (ParameterViewModel)valueGrid.DataContext;
			// Bind the value grid's ItemsSource property to the ParameterViewModel's Items property.
			var itemsBinding = new Binding("Items")
			{
				Source = parameterVm,
				ValidatesOnDataErrors = true
			};
			valueGrid.SetBinding(DataGrid.ItemsSourceProperty, itemsBinding);
			// Bind the value grid's SelectedItem property to the ParameterViewModel's CurrentItem property.
			var currentItemBinding = new Binding("CurrentItem")
			{
				Mode = BindingMode.TwoWay,
				Source = parameterVm,
				UpdateSourceTrigger = UpdateSourceTrigger.LostFocus
			};
			valueGrid.SetBinding(DataGrid.SelectedItemProperty, currentItemBinding);
			// Bind the value grid's SelectedIndex property to the ParameterViewModel's CurrentItemIndex property.
			var currentItemIndexBinding = new Binding("CurrentItemIndex")
			{
				Mode = BindingMode.TwoWay,
				Source = parameterVm,
				UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
			};
			valueGrid.SetBinding(DataGrid.SelectedIndexProperty, currentItemIndexBinding);
		}
		private void OnValueTextBoxInitialized(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			DataGridRow parentRow = VisualTreeHelpers.FindAncestor<DataGridRow>(textBox);
			if (!(parentRow.Item is ParameterViewModel parameterVm))
				return;
			var valueBinding = new Binding("Value")
			{
				Mode = BindingMode.TwoWay,
				Source = parameterVm,
				ValidatesOnDataErrors = true
			};
			textBox.SetBinding(TextBox.TextProperty, valueBinding);
		}
	}

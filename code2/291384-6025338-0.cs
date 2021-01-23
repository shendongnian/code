	public class CustomDataGrid : DataGridControl, IXmlSettingsProvider
	{
		public BSIDataGrid()
		{
			if (DesignModeHelper.IsInDesignMode) return;
			CommandBindings.Add(new CommandBinding(ResetDataGridLayout, ResetDataGridLayoutExecute, ResetDataGridLayoutCanExecute));
			Loaded += (e, a) =>
						  {
							  ...
						  };
			
			LostFocus += (e, a) =>
							 {
								 if(IsBeingEdited && IsTabFocused())
									EndEdit();
							 };
		}
		
		private static bool IsTabFocused()
        {
            var dependencyObject = FocusManager.GetFocusedElement(Application.Current.MainWindow);
            return dependencyObject is TabItem;
        }
	}

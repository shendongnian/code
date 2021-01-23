    class MyCommand : ICommand
	{
		private bool _isEnabled = true;
		public MyCommand(MyTopLevelViewModel viewModel)
		{
			var viewSource = CollectionViewSource.GetDefaultView(viewModel.Tabs);
			viewSource.CurrentChanged += (o,e) =>
				{
					_isEnabled = (viewSource.CurrentItem is EditorTabViewModel); //or however you want to decide
				
					if (this.CanExecuteChanged != null) 
                         this.CanExecuteChanged(this, EventArgs.Empty);
				
				};
		}
	
		public void Execute(object parameter) { /*...*/ }
	
		public bool CanExecute(object parameter) { return _isEnabled; }
	
		public event EventHandler CanExecuteChanged;
	}

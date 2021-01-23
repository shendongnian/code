    private void LoadIncomeStatementViewModel()
	{
		using (var evt = new AutoResetEvent(false))
		{
			EventHandler handler = (sender, e) => evt.Set();
			try
			{
				_incomeStatementViewModel.Loaded += handler;
				_incomeStatementViewModel.LoadDataCommand.Execute(null);
				evt.WaitOne();
			}
			finally
			{
				_incomeStatementViewModel.Loaded -= handler;
			}
		}
	}

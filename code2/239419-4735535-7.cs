    	private DelegateCommand<object> _clickCommand;
		public ICommand ClickCommand
		{
			get
			{
				if (this._clickCommand == null)
				{
					this._clickCommand = new DelegateCommand<object>(p =>
						{
							//command logic
						},
						p =>
						{ 
							// can execute command logic
						});
				}
				return this._clickCommand;
			}
		}

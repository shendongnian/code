	private ViewModelBase _CurrentPage;
	public ViewModelBase CurrentPage
	{
		get { return this._CurrentPage; }
		set
		{
			if (this._CurrentPage != value)
			{
				this._CurrentPage = value;
				RaisePropertyChanged(() => this.CurrentPage);
			}
		}
	}

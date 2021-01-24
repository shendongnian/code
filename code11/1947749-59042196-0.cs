	private bool _Busy = false;
	public bool Busy
	{
		get { return this._Busy; }
		set
		{
			if (this._Busy != value)
			{
				this._Busy = value;
				RaisePropertyChanged(() => this.Busy);
			}
		}
	}

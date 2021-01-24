	private ICommand _KeyDownCommand;
	public ICommand KeyDownCommand => this._KeyDownCommand ?? (this._KeyDownCommand = new RelayCommand<KeyEventArgs>(OnKeyDown));
	private void OnKeyDown(KeyEventArgs args)
	{
		if (args.Key == Key.Return)
		{
			// do something
		}
	}

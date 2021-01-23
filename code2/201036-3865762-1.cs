	protected override void LoadViewState(object savedState)
	{
		Pair state = savedState as Pair;
		if (state != null)
		{
			_isChecked = state.First as Nullable<bool> ?? false;
			this.Text = state.Second as string;
		}
	}
	protected override object SaveViewState()
	{
		return new Pair(_isChecked, this.Text);
	}

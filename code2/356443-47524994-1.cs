	class Example
	{
		private Action _action;
		private void InvokeAction()
		{
			this._action?.Invoke();
		}
	}

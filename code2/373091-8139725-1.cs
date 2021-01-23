        public void Invoke(Action action)
		{
			if (_control.InvokeRequired)
			{
				_control.Invoke(action);
				return;
			}
			action();
		}
		public T Invoke<T>(Func<T> action)
		{
			if (_control.InvokeRequired)
				return (T)_control.Invoke(action);
			return action();
		}

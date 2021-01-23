		protected void AddUndo(Action action)
		{
			var disposable = (IDisposable)null;
			Action inner = () =>
			{
				_disposables.Remove(disposable);
				action();
			};
			disposable = UndoList.AddUndo(inner);
			_disposables.Add(disposable);
		}

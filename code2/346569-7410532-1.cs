	public static class UndoList
	{
		public static bool IsUndoing { get; private set; }
		private static List<Action> _undos = new List<Action>();
		
		public static IDisposable AddUndo(Action action)
		{
			var disposable = (IDisposable)null;
			if (!IsUndoing)
			{			
				disposable = new AnonymousDisposable(() => _undos.Remove(action));
				_undos.Add(action);
			}
			return disposable ?? new AnonymousDisposable(() => { });
		}
		
		public static bool Undo()
		{
			IsUndoing = true;
			var result = _undos.Count > 0;
			if (result)
			{
				var action = _undos[_undos.Count - 1];
				_undos.Remove(action);
				action();
			}
			IsUndoing = false;
			return result;
		}
	}

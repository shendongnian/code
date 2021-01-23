	public class ViewModel : IDisposable, INotifyPropertyChanged
	{
		public ViewModel()
		{
			_disposables = new List<IDisposable>();
			_disposable = new AnonymousDisposable(() =>
				_disposables.ForEach(d => d.Dispose()));
		}
		
		private readonly List<IDisposable> _disposables;
		private readonly IDisposable _disposable;
		
		public void Dispose()
		{
			_disposable.Dispose();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		protected void AddUndo(Action action)
		{ ... }
		
		protected void SetUndoableValue<T>(Action<T> action, T newValue, T oldValue)
		{ ... }
	}

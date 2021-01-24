	public class SomeClass
	{
		private Subject<IObservable<string>> _sources = new Subject<System.IObservable<string>>();
		public IObservable<string> Actions { get; private set; } = null;
	
		public SomeClass()
		{
			this.Actions = _sources.SelectMany(x => x);
		}
		
		public void AddActionCreator(IObservable<string> creator)
		{
			_sources.OnNext(creator);
		}
	}

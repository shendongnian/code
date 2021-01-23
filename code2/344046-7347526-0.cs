	public class EventPublisher : IEventPublisher
	{
		private readonly EventLoopScheduler _scheduler = new EventLoopScheduler(); 
		private readonly Subject<object> _subject = new Subject<object>();
			
		public IObservable<TEvent> GetEvent<TEvent>() 
		{ 
			return _subject
				.Where(o => o is TEvent)
				.Select(o => (TEvent)o)
				.ObserveOn(_scheduler);
		}
		
		public void Publish<TEvent>(TEvent sampleEvent)
		{
			_subject.OnNext(sampleEvent);
		}
	}

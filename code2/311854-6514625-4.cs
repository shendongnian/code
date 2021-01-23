	public class SafeEvent<EventDelegateType> where EventDelegateType:class
	{
		private object collection_lock = new object();
		private Delegate event_handlers;
		public SafeEvent()
		{
			if(!typeof(Delegate).IsAssignableFrom( typeof(EventDelegateType) ))
				throw new ArgumentException( "Generic parameter must be a delegate type." );
		}
	
		public Delegate Handlers
		{
			get
			{
				lock (collection_lock)
					return (Delegate)event_handlers.Clone();
			}
		}
		public void AddEventHandler( EventDelegateType handler )
		{
			lock(collection_lock)
				event_handlers = Delegate.Combine( event_handlers, handler as Delegate );
		}
		public void RemoveEventHandler( EventDelegateType handler )
		{
			lock(collection_lock)
				event_handlers = Delegate.Remove( event_handlers, handler as Delegate );
		}
		public void Raise( object[] args, out List<Exception> errors )
		{
			lock (collection_lock)
			{
				errors = null;
				foreach (Delegate handler in event_handlers.GetInvocationList())
				{
					try {handler.DynamicInvoke( args );}
					catch (Exception err)
					{
						if (errors == null)
							errors = new List<Exception>();
						errors.Add( err );
					}
				}
			}
		}
	}

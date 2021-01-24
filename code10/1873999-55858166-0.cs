	using kvp = KeyValuePair<SendOrPostCallback, object>;
	enum eShutdownReason : byte
	{
		Completed,
		Failed,
		Unexpected,
	}
	class Dispatcher : IDisposable
	{
		const int maxQueueLength = 100;
		readonly ConcurrentQueue<kvp> m_queue;
		readonly BlockingCollection<kvp> m_block;
		public Dispatcher()
		{
			m_queue = new ConcurrentQueue<kvp>();
			m_block = new BlockingCollection<kvp>( m_queue, maxQueueLength );
			createdThreadId = Thread.CurrentThread.ManagedThreadId;
			prevContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext( new SyncContext( this ) );
		}
		readonly SynchronizationContext prevContext;
		readonly int createdThreadId;
		class SyncContext : SynchronizationContext
		{
			readonly Dispatcher dispatcher;
			public SyncContext( Dispatcher dispatcher )
			{
				this.dispatcher = dispatcher;
			}
			// https://blogs.msdn.microsoft.com/pfxteam/2012/01/20/await-synchronizationcontext-and-console-apps/
			public override void Post( SendOrPostCallback cb, object state )
			{
				dispatcher.Post( cb, state );
			}
		}
		/// <summary>Run the dispatcher. Must be called on the same thread that constructed the object.</summary>
		public eShutdownReason Run()
		{
			Debug.Assert( Thread.CurrentThread.ManagedThreadId == createdThreadId );
			while( true )
			{
				kvp h;
				try
				{
					h = m_block.Take();
				}
				catch( Exception ex )
				{
					ex.logError( "Dispatcher crashed" );
					return eShutdownReason.Unexpected;
				}
				if( null == h.Key )
					return (eShutdownReason)h.Value;
				try
				{
					h.Key( h.Value );
				}
				catch( Exception ex )
				{
					ex.logError( "Exception in Dispatcher.Run" );
				}
			}
		}
		/// <summary>Signal dispatcher to shut down. Can be called from any thread.</summary>
		public void Stop( eShutdownReason why )
		{
			Logger.Info( "Shutting down, because {0}", why );
			Post( null, why );
		}
		/// <summary>Post a callback to the queue. Can be called from any thread.</summary>
		public void Post( SendOrPostCallback cb, object state = null )
		{
			if( !m_block.TryAdd( new kvp( cb, state ) ) )
				throw new ApplicationException( "Unable to post a callback to the dispatcher: the dispatcher queue is full" );
		}
		void IDisposable.Dispose()
		{
			Debug.Assert( Thread.CurrentThread.ManagedThreadId == createdThreadId );
			SynchronizationContext.SetSynchronizationContext( prevContext );
		}
	}

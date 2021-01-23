	public static class SPInterlocked
	{
        #region AddHandler, RemoveHandler
        /// <summary>Add an event handler as an atomic operation.</summary>
        /// <returns>True if value is not null; False if null.</returns>
        public static void AddHandler<EVENTHANDLER>(ref EVENTHANDLER handler, EVENTHANDLER value)
            where EVENTHANDLER : class
        {
            Delegate dvalue = value as Delegate;
            if (dvalue == null)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                throw new ArgumentException("Specified value is not a delegate", "value");
            }
            EVENTHANDLER temp;
            EVENTHANDLER current = handler;
            for (int spinner = 0; ; )
            {
                temp = current;
                EVENTHANDLER combined = Delegate.Combine(temp as Delegate, dvalue) as EVENTHANDLER;
                current = Interlocked.CompareExchange(ref handler, combined, temp);
                if (current == temp)
                    break;
                SpinOnce(ref spinner);
            }
            while (current != temp) ;
        }
        /// <summary>Remove an event handler as an atomic operation.</summary>
        /// <returns>True if operation was performed</returns>
        public static bool RemoveHandler<EVENTHANDLER>(ref EVENTHANDLER handler, EVENTHANDLER value)
            where EVENTHANDLER : class
        {
            Delegate dvalue = value as Delegate;
            if (dvalue != null)
            {
                EVENTHANDLER temp;
                EVENTHANDLER current = handler;
                for (int spinner = 0; ; )
                {
                    temp = current;
                    EVENTHANDLER combined = Delegate.Remove(temp as Delegate, dvalue) as EVENTHANDLER;
                    current = Interlocked.CompareExchange(ref handler, combined, temp);
                    if (current == temp)
                        break;
                    SpinOnce(ref spinner);
                }
                return true;
            }
            return false;
        }
        #endregion
	}
	
	public static class MyClass
	{
		private EventHandler eMyEvent;
		
		public event EventHandler MyEvent
		{
			add { SPinterlocked<EventHandler>.AddHandler(ref this.eMyEvent, value); }
			remove { SPinterlocked<EventHandler>.RemoveHandler(ref this.eMyEvent, value); }
		}
	}

	public static class SPInterlocked
	{
		public const int SpinWaitYieldThreshold = 10;
        /// <summary>
        /// Mantain a thread in wait state for a cycle.
        /// spinCounter must be a reference to a local integer variable initialized to zero.
        /// </summary>
        public static void SpinOnce(ref int spinCounter)
        {
            if (spinCounter > SpinWaitYieldThreshold || ProcessorCount <= 1)
            {
                int num = spinCounter >= SpinWaitYieldThreshold ? spinCounter - SpinWaitYieldThreshold : spinCounter;
                Thread.Sleep(num % 20 == 19 ? 1 : 0);
            }
            else
            {
                Thread.SpinWait(2 << spinCounter);
            }
            spinCounter = spinCounter == IntegerMaxValue ? SpinWaitYieldThreshold : spinCounter + 1;
        }
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
	}
	
	// Your code
	public static class MyClass
	{
		private EventHandler eMyEvent;
		
		public event EventHandler MyEvent
		{
			add { SPinterlocked<EventHandler>.AddHandler(ref this.eMyEvent, value); }
			remove { SPinterlocked<EventHandler>.RemoveHandler(ref this.eMyEvent, value); }
		}
	}

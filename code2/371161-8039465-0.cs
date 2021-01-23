	public class LowLock
	{
		int locked = 0;
		public void Enter( Action action )
		{
			var s = new SpinWait();
			while ( true )
			{
				// If CompareExchange equals 0, we won the race.
				if ( Interlocked.CompareExchange( ref locked, 1, 0 ) == 0 )
				{
					action();
					Interlocked.Exchange( ref locked, 0 );
					break; // exit the while loop
				}
					
				s.SpinOnce(); // lost the race. Spin and try again.
			}
		}
	}

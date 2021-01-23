	///<summary>Ensures that a block of code is only executed once at a time.</summary>
	class Valve
	{
		int nextToken;
		///<summary>Returns a unique non-zero token that will indicate that the valve has been entered.</summary>
		int NewToken()
		{
			int next = 0;
			while (next != 0)
				next = Interlocked.Increment(ref nextToken);
			return next;
		}
		int isEntered;	//0 means false; any other value means true
		///<summary>Tries to enter the valve.</summary>
		///<returns>True if no other thread is in the valve; false if the valve has already been entered.</returns>
		public bool TryEnter()
		{
			var myToken = NewToken();
			//I need to find out whether this thread
			//was the one that ended up setting the 
			//flag.  Therefore, each thread needs a 
			//unique token to check for.
			if (Interlocked.CompareExchange(ref isEntered, myToken, 0) == myToken)
				return true;
			return false;
		}
		///<summary>Allows the valve to be entered again.</summary>
		public void Exit()
		{
			isEntered = 0;
		}
	}

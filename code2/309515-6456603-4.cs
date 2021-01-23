	///<summary>Ensures that a block of code is only executed once at a time.</summary>
	class Valve
	{
		int isEntered;	//0 means false; 1 true
		///<summary>Tries to enter the valve.</summary>
		///<returns>True if no other thread is in the valve; false if the valve has already been entered.</returns>
		public bool TryEnter()
		{
			if (Interlocked.CompareExchange(ref isEntered, 1, 0) == 0)
				return true;
			return false;
		}
		///<summary>Allows the valve to be entered again.</summary>
		public void Exit()
		{
			Debug.Assert(isEntered == 1);
			isEntered = 0;
		}
	}

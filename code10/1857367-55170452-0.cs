	private int MyFunction(int number)
	{
		// Code
		for (int i = 0; i <= 10000; i++)
		{
			long value = i * number;		//64bit multiplication			
			long valuePow2 = value * value; //64bit multiplication
			// Some code which uses valuePow2 several times
		}
		return 0; // Not actual line
	}

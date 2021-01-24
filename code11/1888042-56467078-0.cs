	public static T DoSomething<T>(T val)
	{
		switch (val)
		{
			case IEnumerable vals:
				foreach (object x in vals)
					DoSomething(x);
				break;
		}
		
	    return val;
	}

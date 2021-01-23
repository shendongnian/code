	enum SuccessBool
	{
		False = -1,
		Failed = -2,
		failed = -3,
		True = 1,
		Success = 2
	}
    static class SuccessBoolExtenson
	{
		public static bool ToBool(this SuccessBool success)
		{
			return (int)success > 0;
		}
	}

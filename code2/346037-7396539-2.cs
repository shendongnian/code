	public static class AwesomeHelperEx
	{
		public static MyResult ToMyResult(
				this SomeBigExternalDTO input,
				Func<SomeBigExternalDTO, object> selector)
		{
			return new MyResult()
			{
				UserId = input.UserId,
				ResultValue = selector(input).ToString()
			};
		}
	}

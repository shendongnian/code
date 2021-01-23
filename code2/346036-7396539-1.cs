	public static List<MyResult> AwesomeHelper(
		List<SomeBigExternalDTO> input,
		Func<SomeBigExternalDTO, object> selector)
	{
		return input
			.Select(i => new MyResult()
			{
				UserId = i.UserId,
				ResultValue = selector(i).ToString()
			})
			.ToList();
	}

	[TestMethod]
	public void GetEnumerator()
	{
		IList<int> col_mock = MockRepository.GenerateMock<IList<int>>();
		List<int> col_real = new List<int>();
		col_real.Add(1);
		col_real.Add(2);
		col_real.Add(3);
		col_mock
			.Stub(x => x.GetEnumerator())
			.WhenCalled(call => call.ReturnValue = col_real.GetEnumerator())
			.Return(null) // is ignored, but needed for Rhinos validation
			.Repeat.Any();
		foreach (int i in col_mock)
		{
		}
		int count = 0;
		foreach (int i in col_mock)
		{
			count++;
		}
		Assert.AreSame(3, count);
	}

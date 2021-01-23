	public void Test()
	{
		Generic<float> var1 = new Generic<float>(1.5f);
		Generic_float var2 = new Generic_float(2.5f);
		var1 = var2; // Works, var links to var2's memory field casted as Generic<float>
		var2 = var1; // cannot implicitly convert error, if want to use then have to make explicit conversion
	}

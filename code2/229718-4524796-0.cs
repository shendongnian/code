    void Main()
    {
	{
		var ds = Enumerable.Range(1, 30).Select(i => new Random(i).NextDouble());
		ds.Dump();
	}
	{
		var csp = new System.Security.Cryptography.RNGCryptoServiceProvider();
		var bs = new byte[8 * 30];
		var ds = new double[30];
		csp.GetBytes(bs);
		
		for (var i = 0; i < 30; i++)
		{
			var d = BitConverter.ToDouble(bs, i * 8);
			while (d == 0D || Double.IsNaN(d))
			{
				var bytes = new byte[8];
				csp.GetBytes(bytes);
				d = BitConverter.ToDouble(bs, 0);
			}
			ds[i] = Math.Log10(Math.Abs(d));
		}
		
		ds.Dump();
	}
}

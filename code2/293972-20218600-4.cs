	class DelegaTest
	{
		public string F()
		{
			return null;
		}
		public string F(int arg)
		{
			return arg.ToString();
		}
		public void G(int arg1, int arg2)
		{
		}
		/// <summary>
		/// Delegate for `string F()`
		/// </summary>
		public Func<string> D1 => F;
		/// <summary>
		/// Delegate for `string F(int arg)`
		/// </summary>
		public Func<int, string> D2 => F;
		/// <summary>
		/// Delegate for `void G(int arg1, int arg2)`
		/// </summary>
		public Action<int, int> E => G;
	}

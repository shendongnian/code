	class Generic<T>
	{
		public static string ClassName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get 
			{
				return System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
			}
		}
	}

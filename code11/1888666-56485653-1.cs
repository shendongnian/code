	public static class CheckIt
	{
		public static void SetWhenNull(string mightBeNull,ref string notNullable)
		{
			if (mightBeNull != null)
			{
				notNullable = mightBeNull;
			}
		}
	}  

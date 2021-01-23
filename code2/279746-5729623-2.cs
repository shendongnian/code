		public enum TestEnum
		{
			A = 1,
			B = 2
		}
		public static bool EqualsTestEnum(object value, TestEnum enumValue)
		{
			if (value == null || value == DBNull.Value)
			{
				return false;
			}
			int i;
			if (int.TryParse(value.ToString(), out i))
			{
				return i == (int) enumValue;
			}
			return false;
		}

		private static double TicksToOADate(long value)
		{
			if (value == 0L)
			{
				return 0.0;
			}
			if (value < 0xc92a69c000L)
			{
				value += 0x85103c0cb83c000L;
			}
			if (value < 0x6efdddaec64000L)
			{
				throw new OverflowException(Environment.GetResourceString("Arg_OleAutDateInvalid"));
			}
			long num = (value - 0x85103c0cb83c000L) / 0x2710L;
			if (num < 0L)
			{
				long num2 = num % 0x5265c00L;
				if (num2 != 0L)
				{
					num -= (0x5265c00L + num2) * 2L;
				}
			}
			return (((double)num) / 86400000.0);
		}

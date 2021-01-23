    	public static uint TypeCodeToFlag(TypeCode code)
		{
			if (code == TypeCode.String)
			{
				return 0;
			}
			return (uint)((int)code | 0x0100);
		}

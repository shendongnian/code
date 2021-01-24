	private static void SetFlag<T>(ref T value, T flag) where T : Enum
	{
        // 'long' can hold all possible values, except those which 'ulong' can hold.
        if (Enum.GetUnderlyingType(typeof(T)) == typeof(ulong))
        {
            ulong numericValue = Convert.ToUInt64(value);
            numericValue |= Convert.ToUInt64(flag);
            value = (T)Enum.ToObject(typeof(T), numericValue);
        }
        else
        {
            long numericValue = Convert.ToInt64(value);
            numericValue |= Convert.ToInt64(flag);
            value = (T)Enum.ToObject(typeof(T), numericValue);
        }
	}

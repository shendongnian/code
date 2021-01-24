	private static TypeValuesAndNames GetCachedValuesAndNames(RuntimeType enumType, bool getNames)
	{
		TypeValuesAndNames entry = enumType.GenericCache as TypeValuesAndNames;
		if (entry == null || (getNames && entry.Names == null))
		{
			ulong[] values = null;
			string[] names = null;
			GetEnumValuesAndNames(
				enumType.GetTypeHandleInternal(),
				JitHelpers.GetObjectHandleOnStack(ref values),
				JitHelpers.GetObjectHandleOnStack(ref names),
				getNames);
			bool isFlags = enumType.IsDefined(typeof(FlagsAttribute), inherit: false);
			entry = new TypeValuesAndNames(isFlags, values, names);
			enumType.GenericCache = entry;
		}
		return entry;
	}

	public override string ToString()
	{
		// Returns the value in a human readable format.  For PASCAL style enums who's value maps directly the name of the field is returned.
		// For PASCAL style enums who's values do not map directly the decimal value of the field is returned.
		// For BitFlags (indicated by the Flags custom attribute): If for each bit that is set in the value there is a corresponding constant
		// (a pure power of 2), then the OR string (ie "Red, Yellow") is returned. Otherwise, if the value is zero or if you can't create a string that consists of
		// pure powers of 2 OR-ed together, you return a hex value
		// Try to see if its one of the enum values, then we return a String back else the value
		return InternalFormat((RuntimeType)GetType(), ToUInt64()) ?? ValueToString();
	}
	private static string InternalFormat(RuntimeType eT, ulong value)
	{
		Debug.Assert(eT != null);
		// These values are sorted by value. Don't change this
		TypeValuesAndNames entry = GetCachedValuesAndNames(eT, true);
		if (!entry.IsFlag) // Not marked with Flags attribute
		{
			return Enum.GetEnumName(eT, value);
		}
		else // These are flags OR'ed together (We treat everything as unsigned types)
		{
			return InternalFlagsFormat(eT, entry, value);
		}
	}

	public static bool ValueEquality<T>(T val1, object val2) where T : IConvertible
	{
		// make sure val2 implements IConvertible (all numerics and strings do)
		if (!(val2 is IConvertible))
		{
			throw new ArgumentException("The arguments must both implement IConvertible.");
		}
		// convert val2 to type of val1.
		T boxed2 = (T) Convert.ChangeType(val2, typeof (T));
		// compare now that same type.
		return val1.Equals(boxed2);
	}

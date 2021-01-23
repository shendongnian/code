	public static TValue N<TParent, TValue>(TParent o, Func<TParent, TValue> accessor, TValue defaultValue)
	{
		if (o == null)
			return defaultValue;
		return accessor(o);
	}
	/// <summary>
	/// Guarantees return of null or value, given a prop you want to access, even if the parent in the first argument
	/// is null (instead of throwing).
	/// 
	/// Usage:
	/// 
	/// NN.N(myObjThatCouldBeNull, o => o.ChildPropIWant)
	/// </summary>
	/// <returns>The value of the prop. Null if the object is null, or if the child prop is null.</returns>
	public static TValue N<TParent, TValue>(TParent o, Func<TParent, TValue> accessor)
		where TValue : class
	{
		return NN.N(o, accessor, null);
	}

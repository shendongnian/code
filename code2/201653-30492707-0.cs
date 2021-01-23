	/// <summary>
	/// Guarantees return of null or value, given a prop you want to access, even if the parent in the first argument
	/// is null (instead of throwing).
	/// 
	/// Usage:
	/// 
	/// NN.N(myObjThatCouldBeNull, o => o.ChildPropIWant)
	/// </summary>
	/// <returns>Null if that prop is null, or if the child prop is null. The value of the prop if both are set.</returns>
	public static TValue N<TParent, TValue>(TParent o, Func<TParent, TValue> accessor)
		where TValue : class
	{
		return NN.N(o, accessor, null);
	}

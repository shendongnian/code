	/// <summary>
	/// An interface.
	/// </summary>
	/// <typeparam name="TInterface">Type paramter.</typeparam>
	public interface IFace<TInterface>
	{
		/// <summary>
		/// Does the thing.
		/// </summary>
		/// <typeparam name="TMethod">Different from <typeparamref name="TInterface"/>.</typeparam>
		/// <returns>An integer.</returns>
		int SomeMethod<TMethod>();
	} 

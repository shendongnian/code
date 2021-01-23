	#region MultiObject static helper class
	/// <summary>
	/// Provides static methods for creating multi objects with type inference.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public static class MultiList
	{
		/// <summary>
		/// Creates a new <see cref="MultiObject{T1, T2}"/> object instance.
		/// </summary>
		/// <typeparam name="T1">The type of the first object.</typeparam>
		/// <typeparam name="T2">The type of the second object.</typeparam>
		/// <param name="first"><typeparamref name="T1"/> object instance.</param>
		/// <param name="second"><typeparamref name="T2"/> object instance.</param>
		/// <returns>
		/// Returns a <see cref="MultiObject{T1, T2}"/> of <typeparamref name="T1"/> and <typeparamref name="T2"/> object instances.
		/// </returns>
		public static MultiList<T1, T2> New<T1, T2>(IList<T1> first, IList<T2> second)
		{
			return new MultiList<T1, T2>(first, second);
		}
		/// <summary>
		/// Creates a new <see cref="MultiObject{T1, T2, T3}"/> object instance.
		/// </summary>
		/// <typeparam name="T1">The type of the first object.</typeparam>
		/// <typeparam name="T2">The type of the second object.</typeparam>
		/// <typeparam name="T3">The type of the third object.</typeparam>
		/// <param name="first"><typeparamref name="T1"/> object instance.</param>
		/// <param name="second"><typeparamref name="T2"/> object instance.</param>
		/// <param name="third"><typeparamref name="T3"/> object instance.</param>
		/// <returns>
		/// Returns a <see cref="MultiObject{T1, T2, T3}"/> of <typeparamref name="T1"/>, <typeparamref name="T2"/> and <typeparamref name="T3"/> objects instances.
		/// </returns>
		public static MultiList<T1, T2, T3> New<T1, T2, T3>(IList<T1> first, IList<T2> second, IList<T3> third)
		{
			return new MultiList<T1, T2, T3>(first, second, third);
		}
	}
	#endregion
	#region MultiList<T1, T2>
	/// <summary>
	/// Represents a 2-multi object, or pair.
	/// </summary>
	/// <typeparam name="T1">The type of the multi object's first component.</typeparam>
	/// <typeparam name="T2">The type of the multi object's second component.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public class MultiList<T1, T2> : MultiObject<IList<T1>, IList<T2>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiList&lt;T1, T2&gt;"/> class.
		/// </summary>
		/// <param name="first">The first.</param>
		/// <param name="second">The second.</param>
		public MultiList(IList<T1> first, IList<T2> second) : base(first, second) { }
	}
	#endregion
	#region MultiList<T1, T2, T3>
	/// <summary>
	/// Creates a new 3-multi object, or triple.
	/// </summary>
	/// <typeparam name="T1">The value of the first component of the multi object.</typeparam>
	/// <typeparam name="T2">The value of the second component of the multi object.</typeparam>
	/// <typeparam name="T3">The value of the third component of the multi object.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
	public class MultiList<T1, T2, T3> : MultiObject<IList<T1>, IList<T2>, IList<T3>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiList&lt;T1, T2, T3&gt;"/> class.
		/// </summary>
		/// <param name="first">The first.</param>
		/// <param name="second">The second.</param>
		/// <param name="third">The third.</param>
		public MultiList(IList<T1> first, IList<T2> second, IList<T3> third) : base(first, second, third) { }
	}
	#endregion

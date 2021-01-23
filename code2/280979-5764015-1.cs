	#region MultiObject static helper class
	/// <summary>
	/// Provides static methods for creating multi objects with type inference.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public static class MultiObject
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
		public static MultiObject<T1, T2> New<T1, T2>(T1 first, T2 second)
		{
			return new MultiObject<T1, T2>(first, second);
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
		public static MultiObject<T1, T2, T3> New<T1, T2, T3>(T1 first, T2 second, T3 third)
		{
			return new MultiObject<T1, T2, T3>(first, second, third);
		}
	}
	#endregion
	#region MultiObject<T1, T2>
	/// <summary>
	/// Represents a 2-multi object, or pair.
	/// </summary>
	/// <typeparam name="T1">The type of the multi object's first component.</typeparam>
	/// <typeparam name="T2">The type of the multi object's second component.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public class MultiObject<T1, T2>
	{
		/// <summary>
		/// Gets or sets the value of the first multi object component.
		/// </summary>
		/// <value>The first.</value>
		public T1 First { get; set; }
		/// <summary>
		/// Gets or sets the value of the second multi object component.
		/// </summary>
		/// <value>The second multi object component value.</value>
		public T2 Second { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiObject{T1, T2}"/> class.
		/// </summary>
		/// <param name="first">Multi object's first component value.</param>
		/// <param name="second">Multi object's second component value.</param>
		public MultiObject(T1 first, T2 second)
		{
			this.First = first;
			this.Second = second;
		}
	}
	#endregion
	#region MultiObject<T1, T2, T3>
	/// <summary>
	/// Creates a new 3-multi object, or triple.
	/// </summary>
	/// <typeparam name="T1">The value of the first component of the multi object.</typeparam>
	/// <typeparam name="T2">The value of the second component of the multi object.</typeparam>
	/// <typeparam name="T3">The value of the third component of the multi object.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
	public class MultiObject<T1, T2, T3> : MultiObject<T1, T2>
	{
		/// <summary>
		/// Gets or sets the value of the third multi object component.
		/// </summary>
		/// <value>The third multi object component value.</value>
		public T3 Third { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiObject{T1, T2, T3}"/> class.
		/// </summary>
		/// <param name="first">Multi object's first component value.</param>
		/// <param name="second">Multi object's second component value.</param>
		/// <param name="third">Multi object's third component value.</param>
		public MultiObject(T1 first, T2 second, T3 third)
			: base(first, second)
		{
			this.Third = third;
		}
	}
	#endregion

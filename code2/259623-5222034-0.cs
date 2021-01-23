	public static class DelegateCreator
	{
		//-----------------------------------------------------------------------
		public static Action<T, object> SetMethod<T>( PropertyInfo propertyInfo ) 
			where T : class
		{
			MethodInfo method2 = propertyInfo.GetGetMethod( true );
			MethodInfo method = propertyInfo.GetSetMethod( true );
			if( method == null )
			{
				string msg = String.Format( "Property '{0}' does not have a setter.", propertyInfo.Name );
				throw new Exception( msg );
			}
			// First fetch the generic form
			MethodInfo genericHelper = typeof( DelegateCreator ).GetMethod( "CreateSetHelper",
				 BindingFlags.Static | BindingFlags.NonPublic );
			// Now supply the type arguments
			MethodInfo constructedHelper = genericHelper.MakeGenericMethod
				 ( typeof( T ), method2.ReturnType );
			// Now call it. The null argument is because it's a static method.
			object ret = constructedHelper.Invoke( null, new object[] { method } );
			// Cast the result to the right kind of delegate and return it
			return (Action<T, object>)ret;
		}
		//-----------------------------------------------------------------------
		static Action<TTarget, object> CreateSetHelper<TTarget, TParam>( MethodInfo method ) 
			where TTarget : class
		{
			// Convert the slow MethodInfo into a fast, strongly typed, open delegate
			Action<TTarget, TParam> func = (Action<TTarget, TParam>)Delegate.CreateDelegate
				 ( typeof( Action<TTarget, TParam> ), method );
			// Now create a more weakly typed delegate which will call the strongly typed one
			Action<TTarget, object> ret = ( TTarget target, object param ) => func( target, (TParam)param );
			return ret;
		}
		//-----------------------------------------------------------------------
		public static Func<T, object> GetMethod<T>( PropertyInfo propertyInfo ) 
			where T : class
		{
			MethodInfo method = propertyInfo.GetGetMethod( true );
			if( method == null )
			{
				string msg = String.Format( "Property '{0}' does not have a getter.", propertyInfo.Name );
				throw new Exception( msg );
			}
			// First fetch the generic form
			MethodInfo genericHelper = typeof( DelegateCreator ).GetMethod( "CreateGetHelper",
				 BindingFlags.Static | BindingFlags.NonPublic );
			// Now supply the type arguments
			MethodInfo constructedHelper = genericHelper.MakeGenericMethod
				 ( typeof( T ), method.ReturnType );
			// Now call it. The null argument is because it's a static method.
			object ret = constructedHelper.Invoke( null, new object[] { method } );
			// Cast the result to the right kind of delegate and return it
			return (Func<T, object>)ret;
		}
		//-----------------------------------------------------------------------
		static Func<TTarget, object> CreateGetHelper<TTarget, TReturn>( MethodInfo method )
			where TTarget : class
		{
			// Convert the slow MethodInfo into a fast, strongly typed, open delegate
			Func<TTarget, TReturn> func = (Func<TTarget, TReturn>)Delegate.CreateDelegate
				 ( typeof( Func<TTarget, TReturn> ), method );
			// Now create a more weakly typed delegate which will call the strongly typed one
			Func<TTarget, object> ret = ( TTarget target ) => func( target );
			return ret;
		}
	}

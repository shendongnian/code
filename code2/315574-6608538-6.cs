    static class StaticReflection<TClass>
	{
		static string PublicConstructorParameterName<TParameter>()
		{
			return typeof( TClass ).GetConstructors( BindingFlags.Public | BindingFlags.Instance ).Single().GetParameters().Where( param => param.ParameterType == typeof( TParameter ) ).Single().Name;
		}
		internal static ConstructorArgument CreateConstructorArgument<TParameter>( TParameter value )
		{
			return new ConstructorArgument( PublicConstructorParameterName<TParameter>(), value );
		}
		internal static ConstructorArgument CreateConstructorArgument<TParameter>( Func<IContext, TParameter> argumentResolver )
		{
			return new ConstructorArgument( PublicConstructorParameterName<TParameter>(), context => (object)argumentResolver( context ) );
		}
	}

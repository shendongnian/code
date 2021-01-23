	public static IList<Tuple<Type, Type[], GenericParameterAttributes>> GetTypeConstraints( this Type type )
	{
		return type.GetGenericArguments()
			.Select( t => Tuple.Create( t, t.GetGenericParameterConstraints(), t.GenericParameterAttributes ) )
			.Where( t => t.Item2.Length > 0 || t.Item3 > GenericParameterAttributes.None )
			.ToList();
	}

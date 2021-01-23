		public static Converter<Object, T> CreateDynamicConverter<T>()
		{
			var param = Expression.Parameter(typeof(object)); 
			var expression = Expression.Lambda<Converter<object, T>>(
				Expression.Condition(
					Expression.Equal(
						param,
						Expression.Constant(
							DBNull.Value
						)
					),
					Expression.Default(
						typeof(T)
					),
					Expression.Dynamic(
						Binder.Convert(
							CSharpBinderFlags.ConvertExplicit, 
							typeof(T), 
							typeof(MyApplicationNameHere)
						), 
						typeof(T), 
						param
					)
				),
				param
			);
			return expression.Compile();
		}

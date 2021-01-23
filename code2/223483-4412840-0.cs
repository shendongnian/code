		public static Func<T, T, bool> BuildStructuralComparerDelegate<T>() where T:class
		{
			var left = Expression.Parameter(typeof(T), "left");
			var right = Expression.Parameter(typeof(T), "right");
			var referenceEquals = typeof(object).GetMethod("ReferenceEquals");
			Expression expression = Expression.AndAlso(
				Expression.Not(
					Expression.Call(
                        null,
						referenceEquals,
						left,
						Expression.Default(typeof(T))
					)
				),
				Expression.Not(
                    null,
					Expression.Call(
						referenceEquals,
						right,
						Expression.Default(typeof(T))
					)
				)
			);
			Array.ForEach(typeof(T).GetProperties(),property =>
				expression = Expression.AndAlso(
					expression,
					Expression.Equal(
						Expression.Property(left, property),
						Expression.Property(right, property)
					)
				)
			);
			var lambdaExp = Expression.Lambda<Func<T, T, bool>>(
				Expression.OrElse(
					Expression.Call(
                        null,
						referenceEquals,
						left,
						right
					),
					expression
				),
				left,
				right
			);
			return lambdaExp.Compile();
		}

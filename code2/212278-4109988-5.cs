			private static Func<TEnum, TEnum, bool> CreateHasFlagDelegate2()
			{
				if(!typeof(TEnum).IsEnum)
				{
					throw new ArgumentException(string.Format("{0} is not an Enum", typeof(TEnum)), typeof(EnumExtensionsInternal<>).GetGenericArguments()[0].Name);
				}
				ParameterExpression valueExpression = Expression.Parameter(
						typeof(TEnum),
						typeof(TEnum).Name
				);
				ParameterExpression flagExpression = Expression.Parameter(
						typeof(TEnum),
						typeof(TEnum).Name
				);
				var targetType = Type.GetTypeCode(typeof(TEnum)) == TypeCode.UInt64 ? typeof(ulong) : typeof(long);
				Expression<Func<TEnum, TEnum, bool>> lambdaExpression = Expression.Lambda<Func<TEnum, TEnum, bool>>(
								Expression.Equal(
										Expression.And(
												Expression.Convert(
														valueExpression,
														targetType
												),
												Expression.Convert(
													flagExpression,
													targetType
												)
										),
										Expression.Convert(
											flagExpression,
											targetType
										)
								),
						valueExpression,
						flagExpression
				);
				return lambdaExpression.Compile();
			}

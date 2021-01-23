			Type targetType;
			bool isNullable;
			// Do we have a nullable type?
			if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
			{
				isNullable = true;
				targetType = type.GetGenericArguments()[0];
			}
			else
			{
				isNullable = false;
				targetType = type;
			}

    	void Traverse(Type type, ISet<Type> marks, ICollection<PropertyInfo> result)
		{
			if (marks.Contains(type)) return; else marks.Add(type);
			foreach (var propertyInfo in type.GetProperties())
				if (propertyInfo.PropertyType.IsPrimitive) result.Add(propertyInfo);
				else Traverse(propertyInfo.PropertyType, marks, result);
		}

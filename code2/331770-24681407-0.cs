    	public void ListAllDerviedTypes()
		{
			Type entityType = typeof(TableAdapter);
			Assembly assembly = Assembly.LoadFrom(entityType.Assembly.Location);
			Type[] types = assembly.GetTypes();
			List<Type> results = new List<Type>();
			GetAllDerivedTypesRecursively(types, typeof(SiteAndSectorsTable<>), ref results);
			foreach (var type in results)
			{
				Console.WriteLine(type.Name);
			}
		}
		private static void GetAllDerivedTypesRecursively(Type[] types, Type type1, ref List<Type> results)
		{
			if (type1.IsGenericType)
			{
				GetDerivedFromGeneric(types, type1, ref results);
			}
			else
			{
				GetDerivedFromNonGeneric(types, type1, ref results);
			}
		}
		private static void GetDerivedFromGeneric(Type[] types, Type type, ref List<Type> results)
		{
			var derivedTypes = types
				.Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
				            t.BaseType.GetGenericTypeDefinition() == type).ToList();
			results.AddRange(derivedTypes);
			foreach (Type derivedType in derivedTypes)
			{
				GetAllDerivedTypesRecursively(types, derivedType, ref results);
			}
		}
		public static void GetDerivedFromNonGeneric(Type[] types, Type type, ref List<Type> results)
		{
			var derivedTypes = types.Where(t => t != type && type.IsAssignableFrom(t)).ToList();
			results.AddRange(derivedTypes);
			foreach (Type derivedType in derivedTypes)
			{
				GetAllDerivedTypesRecursively(types, derivedType, ref results);
			}
		} 

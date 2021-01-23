			IEnumerable<Type> types = Assembly.GetExecutingAssembly()
				.GetTypes().Where(t=>t.GetInterfaces().Where(tt==typeof(IExample)).Count()>0);
			List<object> objects = new List<object>();
			foreach (Type type in types)
			{
				objects.Add(Activator.CreateInstance(type));
			}

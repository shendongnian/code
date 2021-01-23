		foreach (Type t in types)
		{
			foreach (FieldInfo o in t.GetFields())
			{
				// As this is a static field no instance of type 't' is
				// required to get the field value, so just pass null
				ReferenceObject value = o.GetValue(null) as ReferenceObject;
				Console.WriteLine("{0}.{1} = {2}", t, o.Name, value);
			}
			Console.WriteLine();
		}

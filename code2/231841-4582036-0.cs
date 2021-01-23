	// untested, just demonstates concept
	class MapCopier
	{
		private static void GenericCopy<TValue>(Field<TValue> field, IFieldMap from, IFieldMap to)
		{
			to.Put(field, from.Get(field));
		}
		public void Copy(IEnumerable<IUntypedField> fields, IFieldMap from, IFieldMap to)
		{
			var genericMethod = typeof(MapCopier).GetMethod("GenericCopy");
			foreach(var field in fields)
			{
				var method = genericMethod.MakeGenericMethod(field.Type);
				method.Invoke(null, new object[] { field, from, to });
			}
		}
	}

	static class ReflectionExtensions
	{
		public static IEnumerable<object> AllProperties(this object root)
		{
			return root.GetType().GetProperties().Select((p) => p.GetValue(root));
		}
		public static IEnumerable<T> AllProperties<T>(this object root)
		{
			return root.GetType().GetProperties().Select((p) => p.GetValue(root)).OfType<T>();
		}
		public static object Property(this object root, string propName)
		{
			return root.GetType().GetProperty(propName).GetValue(root);
		}
	}
	private IReadOnlyList<DynamicProperty> CombineProperties(DynamicData deserializedRawData)
	{
		return (from formGroup in deserializedRawData.AllProperties()
				let formGroupType = FormHelper.GetFormGroupType(formGroup.GetType().Name)
				let properties = formGroup.Property("Properties")
				from fieldInfo in properties.AllProperties<DynamicDataFieldInfo>()
				select new DynamicProperty { DynamicDataFieldInfo = fieldInfo, GroupType = formGroupType }).ToList()
	}

	private static void ClearReadOnly(ConfigurationElement element) {
		for (Type type = element.GetType(); type != null; type = type.BaseType) {
			foreach (FieldInfo field in type.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.DeclaredOnly).Where(f => typeof(bool).IsAssignableFrom(f.FieldType) && f.Name.EndsWith("ReadOnly", StringComparison.OrdinalIgnoreCase))) {
				field.SetValue(element, false);
			}
		}
	}

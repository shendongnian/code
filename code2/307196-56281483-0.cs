	public static class TypeExtensions {
		public static String GetName(this Type t) {
			String readable;
	#if PREVENT_RECURSION
			if(m_names.TryGetValue(t, out readable)) {
				return readable;
			}
	#endif
			var tArgs = t.IsGenericType ? t.GetGenericArguments() : Type.EmptyTypes;
			var name = t.Name;
			var format = Regex.Replace(name, @"`\d+.*", "")+(t.IsGenericType ? "<?>" : "");
			var names = tArgs.Select(x => x.IsGenericParameter ? "" : GetName(x));
			readable=String.Join(String.Join(",", names), format.Split('?'));
	#if PREVENT_RECURSION
			m_names.Add(t, readable);
	#endif
			return readable;
		}
		static readonly Dictionary<Type, String> m_names = new Dictionary<Type, String> { };
	}

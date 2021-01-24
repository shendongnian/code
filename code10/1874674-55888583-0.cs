	public static partial class Extensions
	{
		private static Dictionary<string, MO> _lookup =
			Enum
				.GetNames(typeof(MO))
				.ToDictionary(n => n, n => n.ToMode());
				
		public static bool TryParseMode(this string mode, out MO value)
		{
			var found = _lookup.ContainsKey(mode);
			value = found ? _lookup[mode] : default(MO);
			return found;
		}
		
		public static MO ToMode(this string mode) => (MO)Enum.Parse(typeof(MO), mode);
	}

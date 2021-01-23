    public static class ColorExtensions
    {
		private static Lazy<Dictionary<uint, KnownColor>> knownColors = new Lazy<Dictionary<uint, KnownColor>>(() =>
		{
			Dictionary<uint, KnownColor> @out = new Dictionary<uint, KnownColor>();
			foreach (var val in Enum.GetValues(typeof(KnownColor)))
			{
				Color col = Color.FromKnownColor((KnownColor)val);
				@out[col.PackColor()] = (KnownColor)val;
			}
			return @out;
		});
		
		/// <summary>Packs a Color structure into a single uint (argb format).</summary>
		/// <param name="color">The color to package.</param>
		/// <returns>uint containing the packed color.</returns>
		public static uint PackColor(this Color color) => (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
		
		/// <summary>Unpacks a uint containing a Color structure.</summary>
		/// <param name="color">The color to unpackage.</param>
		/// <returns>A new Color structure containing the color defined by color.</returns>
		public static Color UnpackColor(this uint color) => Color.FromArgb((byte)(color >> 24), (byte)(color >> 16), (byte)(color >> 8), (byte)(color >> 0));
		
		/// <summary>Gets the name of the color</summary>
		/// <param name="color">The color to get the KnownColor for.</param>
		/// <returns>A new KnownColor structure.</returns>
		public static KnownColor? GetKnownColor(this Color color)
		{
			KnownColor @out;
			if (knownColors.Value.TryGetValue(color.PackColor(), out @out))
				return @out;
		
			return null;
		}
    }

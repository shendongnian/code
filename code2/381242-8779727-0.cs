	public sealed class FontFamilyExtension:MarkupExtension
	{
		public FontFamily FontFamily { get; set; }
		public FontFamilyExtension(FontFamily fontFamily)
		{
			FontFamily = fontFamily;
		}
		[Conditional("DEBUG")]
		private void TestFont()
		{
			if (!Fonts.SystemFontFamilies.Contains(FontFamily))
				Console.WriteLine("Font '{0}' not found.", FontFamily.Source);
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			TestFont();
			return FontFamily;
		}
	}

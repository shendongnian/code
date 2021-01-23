	public static class BitmapFont
	{
		private class FontInfo
		{
			public FontInfo(WriteableBitmap image, Dictionary<char, Rect> metrics, int size)
			{
				this.Image = image;
				this.Metrics = metrics;
				this.Size = size;
			}
			public WriteableBitmap Image { get; private set; }
			public Dictionary<char, Rect> Metrics { get; private set; }
			public int Size { get; private set; }
		}
		private static Dictionary<string, List<FontInfo>> fonts = new Dictionary<string, List<FontInfo>>();
		public static void RegisterFont(string name,params int[] sizes)
		{
			foreach (var size in sizes)
			{
				string fontFile = name + " " + size + ".png";
				string fontMetricsFile = name + " " + size + ".xml";
				BitmapImage image = new BitmapImage();
				image.SetSource(App.GetResourceStream(new Uri(fontFile, UriKind.Relative)).Stream);
				var metrics = XDocument.Load(fontMetricsFile);
				var dict = (from c in metrics.Root.Elements()
				            let key = (char) ((int) c.Attribute("key"))
				            let rect = new Rect((int) c.Element("x"), (int) c.Element("y"), (int) c.Element("width"), (int) c.Element("height"))
				            select new {Char = key, Metrics = rect}).ToDictionary(x => x.Char, x => x.Metrics);
				var fontInfo = new FontInfo(new WriteableBitmap(image), dict, size);
				if(fonts.ContainsKey(name))
					fonts[name].Add(fontInfo);
				else
					fonts.Add(name, new List<FontInfo> {fontInfo});
			}
		}
		private static FontInfo GetNearestFont(string fontName,int size)
		{
			return fonts[fontName].OrderBy(x => Math.Abs(x.Size - size)).First();
		}
		public static Size MeasureString(string text,string fontName,int size)
		{
			var font = GetNearestFont(fontName, size);
			double scale = (double) size / font.Size;
			var letters = text.Select(x => font.Metrics[x]).ToArray();
			return new Size(letters.Sum(x => x.Width * scale),letters.Max(x => x.Height * scale));
		}
		public static void DrawString(this WriteableBitmap bmp,string text,int x,int y, string fontName,int size,Color color)
		{
			var font = GetNearestFont(fontName, size);
			var letters = text.Select(f => font.Metrics[f]).ToArray();
			double scale = (double)size / font.Size;
			double destX = x;
			foreach (var letter in letters)
			{
				var destRect = new Rect(destX,y,letter.Width * scale,letter.Height * scale);
				bmp.Blit(destRect, font.Image, letter, color, WriteableBitmapExtensions.BlendMode.Alpha);
				destX += destRect.Width;
			}
		}
	}

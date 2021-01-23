		private static Dictionary<string, Color> colorDictionary;
		public static Dictionary<string, Color> ColorDictionary
		{
			get
			{
				if (colorDictionary== null) {
					colorDictionary = new Dictionary<string, Color>();
					var all = Enum.GetValues(typeof(Color)).OfType<Color>();
					foreach (var val in all)
						dict.Add(val.ToString(), val);
				}
				return colorDictionary;
			}
		}

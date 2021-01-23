	public static class XmlTextExtentions
	{
		private static readonly Dictionary<char, string> textEntities = new Dictionary<char, string> {
			{ '&', "&amp;"}, { '<', "&lt;" }, { '>', "&gt;" }, 
			{ '"', "&quot;" }, { '\'', "&apos;" }
		};
		public static string ToValidXmlString(this string str)
		{
			var stripped = str
				.Select((c,i) => new 
				{ 
					c1 = c, 
					c2 = i + 1 < str.Length ? str[i+1]: default(char),
					v = XmlConvert.IsXmlChar(c),
					p = i + 1 < str.Length ? XmlConvert.IsXmlSurrogatePair(str[i + 1], c) : false,
					pp = i > 0 ? XmlConvert.IsXmlSurrogatePair(c, str[i - 1]) : false
				})
				.Aggregate("", (s, c) => {					
					if (c.pp)
						return s;
					if (textEntities.ContainsKey(c.c1))
						s += textEntities[c.c1];
					else if (c.v)
						s += c.c1.ToString();
					else if (c.p)
						s += c.c1.ToString() + c.c2.ToString();
					return s;
				});
			return stripped;
		}
	}

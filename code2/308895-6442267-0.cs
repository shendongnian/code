    public static class MyExtensions
	{
		public static string ToString(this System.Xml.XmlNode node, int indentation)
		{
			using (var sw = new System.IO.StringWriter())
			{
				using (var xw = new System.Xml.XmlTextWriter(sw))
				{
					xw.Formatting = System.Xml.Formatting.Indented;
					xw.Indentation = indentation;
					node.WriteContentTo(xw);
				}
				return sw.ToString();
			}
		}
	}

		static void ReadXml()
		{
			string a = null;
			long b = 0;
			double c = 0;
			string text = "<a><b>26a83f12c782</b><c>128</c><d>12</d></a>";
			string element = "";
			using (XmlReader xmlReader = new XmlTextReader(new StringReader(text)))
			{
				while (xmlReader.Read())
				{
					if (xmlReader.NodeType == XmlNodeType.Element)
					{
						element = xmlReader.Name;
					}
					else if (xmlReader.NodeType == XmlNodeType.Text)
					{
						switch (element)
						{
							case "a":
								a = xmlReader.Value;
								Console.WriteLine("a: " + a);
								break;
							case "b":
								b = long.Parse(xmlReader.Value, NumberStyles.HexNumber);
								Console.WriteLine("b: " + b);
								break;
							case "c":
								c = double.Parse(xmlReader.Value);
								Console.WriteLine("c: " + c);
								break;
						}
					}
				}
			}
		}

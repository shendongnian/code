		public static void TestXmlCleanser()
		{
			string badString = "My name is Inigo Montoya"; // you may not see it, but bad char is in 'MontXoya'
			string goodString = "My name is Inigo Montoya!";
			string back1 = XML.ToValidXmlCharactersString(badString); // fixes it
			string back2 = XML.ToValidXmlCharactersString(goodString); // returns same string
			XElement x1 = new XElement("test", back1);
			XElement x2 = new XElement("test", back2);
			XElement x3WithBadString = new XElement("test", badString);
			string xml1 = x1.ToString();
			string xml2 = x2.ToString().Print();
			string xmlShouldFail = x3WithBadString.ToString();
        }

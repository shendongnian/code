		public static void TestXmlCleanser()
		{
			string badString = "My name is Inigo Montoya"; // you may not see it, but bad char is in 'MontXoya'
			XElement x = new XElement("test", badString);
			string xml1 = x.ToStringIgnoreInvalidChars();								
			//result: <test>My name is Inigo Montoya</test>
			string xml2 = x.ToStringIgnoreInvalidChars(deleteInvalidChars: false);
			//result: <test>My name is Inigo Mont&#x1E;oya</test>
		}

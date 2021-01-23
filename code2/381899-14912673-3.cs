	void Main() {
		string content = "\v\f\0";
		Console.WriteLine(IsValidXmlString(content)); // False
		
		content = XmlConvert.EncodeName(content);
		Console.WriteLine(IsValidXmlString(content)); // True
	}
	
	static bool IsValidXmlString(string text) {
		try {
			XmlConvert.VerifyXmlChars(text);
			return true;
		} catch {
			return false;
		}
	}

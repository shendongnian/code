	void Main() {
		string content = "\v\f\0";
		Console.WriteLine(IsValidXmlString(content));
		
		content = XmlConvert.EncodeName(content);
		Console.WriteLine(IsValidXmlString(content));
	}
	
	static bool IsValidXmlString(string text) {
		try {
			XmlConvert.VerifyXmlChars(text);
			return true;
		} catch {
			return false;
		}
	}

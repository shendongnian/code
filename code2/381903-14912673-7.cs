	void Main() {
	    const string content = "\v\f\0";
	    Console.WriteLine(IsValidXmlString(content)); // False
	
	    string encoded = XmlConvert.EncodeName(content);
	    Console.WriteLine(IsValidXmlString(encoded)); // True
	    
	    string decoded = XmlConvert.DecodeName(encoded);
	    Console.WriteLine(content == decoded); // True
	}
	
	static bool IsValidXmlString(string text) {
		try {
			XmlConvert.VerifyXmlChars(text);
			return true;
		} catch {
			return false;
		}
	}

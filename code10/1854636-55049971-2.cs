	var encoding = Encoding.GetEncoding(
		"US-Ascii",
		new EncoderReplacementFallback("�"),
		new DecoderReplacementFallback("�"));
	Console.WriteLine(encoding.GetString(new byte[]{234})); // Prints �
	var bytes = encoding.GetBytes("þ"); // Throws Argument Exception:
                                        // Recursive fallback not allowed for character \uFFFD.
                                        // Parameter name: chars

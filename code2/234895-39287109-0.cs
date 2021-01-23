    public string IncrementString(string inboundString)    {
	byte[] bytes = System.Text.Encoding.ASCII.GetBytes(inboundString.ToArray);
	bool incrementNext = false;
	for (l = -(bytes.Count - 1); l <= 0; l++) {
		incrementNext = false;
		int bIndex = Math.Abs(l);
		int asciiVal = Conversion.Val(bytes(bIndex).ToString);
		asciiVal += 1;
		if (asciiVal > 57 & asciiVal < 65)
			asciiVal = 65;
		if (asciiVal > 90) {
			asciiVal = 48;
			incrementNext = true;
		}
		bytes(bIndex) = System.Text.Encoding.ASCII.GetBytes({ Strings.Chr(asciiVal) })(0);
		if (incrementNext == false)
			break; // TODO: might not be correct. Was : Exit For
	}
	inboundString = System.Text.Encoding.ASCII.GetString(bytes);
	return inboundString;
    }

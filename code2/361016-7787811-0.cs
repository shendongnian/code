	Console.WriteLine("{0,33}\t{1,33}", "Original Value", "New Value");
	Console.WriteLine("{0}\t{0}", new String('-', 33));
	
	for (int i = -12; i <= 12; i++)
	{
		string sign = i < 0 ? "" : "+";
		string originalString = String.Format(
			"2011-10-01T01:18:54.6652123{0}{1:D2}:00", sign, i);
		DateTimeOffset dateTime = XmlConvert.ToDateTimeOffset(originalString);
		string newString = XmlConvert.ToString(dateTime);
		Console.WriteLine("{0}\t{1}", originalString, newString);
	}

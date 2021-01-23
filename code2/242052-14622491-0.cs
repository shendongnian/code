    public static string PlainTextToRtf(string plainText)
    {
		if (string.IsNullOrEmpty(plainText))
			return "";
			
		string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
		escapedPlainText = EncodeCharacters(escapedPlainText);
		
		string rtf = @"{\rtf1\ansi\ansicpg1250\deff0{\fonttbl\f0\fswiss Helvetica;}\f0\pard ";
		rtf += escapedPlainText.Replace(Environment.NewLine, "\\par\r\n ") + ;
		rtf += " }";
		return rtf;
    }

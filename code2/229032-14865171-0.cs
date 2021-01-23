    private bool EncodeText(string val)
    		{
    			string decodedText = HttpUtility.HtmlDecode(val);
    			string encodedText = HttpUtility.HtmlEncode(decodedText);
    
    			return encodedText.Equals(val, StringComparison.OrdinalIgnoreCase);
    			
    		}

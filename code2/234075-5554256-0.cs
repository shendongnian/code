		private object NormalizeString(object p) {
			object result = p;
			if (p is string || p is long) {
				string s = string.Format("{0}", p);
				string resultString = s.Trim();
				if (string.IsNullOrWhiteSpace(resultString)) return "";
				Regex rxInvalidChars = new Regex("[\r\n\t]+", RegexOptions.IgnoreCase);
				if (rxInvalidChars.IsMatch(resultString)) {
					resultString = rxInvalidChars.Replace(resultString, " ");
				}
				//string pattern = String.Empty;
				//pattern = @"";
				////pattern =  @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F])"; //XML 1.0
				////pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF])"; // XML 1.1
				//Regex rxInvalidXMLChars = new Regex(pattern, RegexOptions.IgnoreCase);
				//if (rxInvalidXMLChars.IsMatch(resultString)) {
				//    resultString = rxInvalidXMLChars.Replace(resultString, "");
				//}
				result = string.Join("", resultString.Where(c => c >= ' '));
			}
			return result;
		}

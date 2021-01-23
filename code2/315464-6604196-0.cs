     private static bool ValidateSequenceNumber(string val, string num) {
         System.Globalization.CultureInfo inv=System.Globalization.CultureInfo.InvariantCulture;
			int seqNumber = unchecked((((int)Double.Parse(num,System.Globalization.NumberStyles.Any,inv) + 0xCED9) * 0x8088405) & 0xFFFF);
			string checksum = seqNumber.ToString("X",inv).ToUpperInvariant();
			if (checksum != val.Substring(11, 4)) {
				return false;
			}
			return true;
		}

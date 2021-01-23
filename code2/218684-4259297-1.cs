	using System.Globalization;
	using System.Text.RegularExpressions;
	string IP_UpperLimit = "192.168.1.255";
	string IP_LowerLimit = "192.168.1.1";
	string Mac_UpperLimit = "99-EE-EE-EE-EE-EE";
	string Mac_LowerLimit = "00-00-00-00-00-00";
	string IP_WithinLimit = "192.168.1.100";
	string IP_OutOfBounds = "10.10.1.1";
	string Mac_WithinLimit = "00-AA-11-BB-22-CC";
	string Mac_OutOfBounds = "AA-11-22-33-44-55";
	Console.WriteLine("IP Addresses:");
	Console.WriteLine("Upper Limit: " + ConvertIP(IP_UpperLimit));
	Console.WriteLine("Lower Limit: " + ConvertIP(IP_LowerLimit));
	Console.WriteLine("IP_WithinLimit: " + ConvertIP(IP_WithinLimit));
	Console.WriteLine("IP_OutOfBounds: " + ConvertIP(IP_OutOfBounds));
	Console.WriteLine();
	Console.WriteLine();
	Console.WriteLine("Mac Addresses:");
	Console.WriteLine("Upper Limit: " + ConvertMac(Mac_UpperLimit));
	Console.WriteLine("Lower Limit: " + ConvertMac(Mac_LowerLimit));
	Console.WriteLine("Mac_WithinLimit: " + ConvertMac(Mac_WithinLimit));
	Console.WriteLine("Mac_OutOfBounds: " + ConvertMac(Mac_OutOfBounds));
	long ConvertIP(string IP)
	{
		// http://www.justin-cook.com/wp/2006/11/28/convert-an-ip-address-to-ip-number-with-php-asp-c-and-vbnet/
		Regex r = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
		if (!r.Match(IP).Success) return 0L;
		string[] IPSplit = IP.Split('.');
		long IPNum = 0L;
		for (int i = IPSplit.Length - 1; i >= 0; i--)
			IPNum += ((Int64.Parse(IPSplit[i]) % 256) * (long)Math.Pow(256, (3 - i)));
		return IPNum;
	}
	long ConvertMac(string Mac)
	{
		Regex r = new Regex(@"^[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}$");
		if (!r.Match(Mac).Success) return 0L;
		return Int64.Parse(Mac.Replace("-", String.Empty), NumberStyles.HexNumber);
	}

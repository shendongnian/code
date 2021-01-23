	string input = @"such as () and § untouched.";
	//Console.WriteLine(input);
	Console.WriteLine(HttpUtility.UrlEncodeUnicode(input));
	Console.WriteLine(HttpUtility.UrlEncode(input));
	string everything = string.Join("", input.ToCharArray().Select(c => "%" + ((int)c).ToString("x2")).ToArray());
	Console.WriteLine(everything);
	Console.WriteLine(HttpUtility.UrlDecode(everything));
	//This is my understanding of what you're asking for:
	string everythingU = string.Join("", input.ToCharArray().Select(c => "%u" + ((int)c).ToString("x4")).ToArray());
	Console.WriteLine(everythingU);
	Console.WriteLine(HttpUtility.UrlDecode(everythingU));

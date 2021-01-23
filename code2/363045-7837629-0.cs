	string saying = "למכות is in כתר"; //Just because it amuses me that this is a saying whatever way round the browser puts malkuth and kether.
	string kether = "כתר";
	Console.WriteLine(new Regex(kether, RegexOptions.RightToLeft).IsMatch(saying));//True
	Console.WriteLine(new Regex(kether, RegexOptions.None).IsMatch(saying));//True, perhaps minutely faster but so little that noise would hide it.
	Console.WriteLine(new Regex(kether, RegexOptions.RightToLeft).IsMatch(saying, 2));//False
	Console.WriteLine(new Regex(kether, RegexOptions.None).IsMatch(saying, 2));//True
	//And to show that the ordering is codepoint rather than physical display ordering:
	Console.WriteLine(new Regex("" + kether[0] + ".*" + kether[2]).IsMatch(saying));//True
	Console.WriteLine(new Regex("" + kether[2] + ".*" + kether[0]).IsMatch(saying));//False

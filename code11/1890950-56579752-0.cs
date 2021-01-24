	public static void Main()
	{
		Console.WriteLine("Hello World");
		
		const char rtl = (char)0x200E;
		var replace = "سنغافورة";
		
		var input = "York Hotel في [CITY] – " + rtl + "عروض الغرف، صور وتقييمات";
		Console.WriteLine(input);
		var final = input.Replace("[CITY]", replace);
		Console.WriteLine(final);
	}

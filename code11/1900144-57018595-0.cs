	CultureInfo c;
	var dt = new DateTime(2019,7,7);
	
	c = new CultureInfo("fr-FR");
	Console.WriteLine($"{c}: {c.DateTimeFormat.ShortDatePattern}");
	Console.WriteLine(dt.ToString($"{c.DateTimeFormat.ShortDatePattern} (dddd)", c.DateTimeFormat));
	Console.WriteLine();
	
	c = new CultureInfo("de-DE");
	Console.WriteLine($"{c}: {c.DateTimeFormat.ShortDatePattern}");
	Console.WriteLine(dt.ToString($"{c.DateTimeFormat.ShortDatePattern} (dddd)", c.DateTimeFormat));
	Console.WriteLine();
	
	c = new CultureInfo("en-EN");
	Console.WriteLine($"{c}: {c.DateTimeFormat.ShortDatePattern}");
	Console.WriteLine(dt.ToString($"{c.DateTimeFormat.ShortDatePattern} (dddd)", c.DateTimeFormat));
	Console.WriteLine();

	Console.WriteLine(DateTime.Now.ToString("MM", new System.Globalization.CultureInfo("ar-SA")));
	Console.WriteLine(DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("ar-SA")));
	
	Console.WriteLine(DateTime.Now.ToString("MM", System.Globalization.CultureInfo.InvariantCulture));
	Console.WriteLine(DateTime.Now.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));

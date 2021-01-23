	Console.WriteLine(Extension.TrimStr("My Sammy", "my", true));
	Console.WriteLine(Extension.TrimStr("My Sammy", "my", false));
	Console.WriteLine("Sammy".TrimEnd("my"));
	Console.WriteLine("My o My".TrimEnd("My"));
	Console.WriteLine("My o My".TrimStart("My"));
	Console.WriteLine("moinmoin gibts gips? gips gibts moin".TrimStart("moin", false));
	Console.WriteLine("moinmoin gibts gips? gips gibts moin".Trim("moin").Trim());

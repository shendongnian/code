	int a = 5;
	int b = 5;
	
	Console.WriteLine(a == b); // true
	Console.WriteLine(a.Equals(b)); // true
	Console.WriteLine((object)a == (object)b); // false
	Console.WriteLine(((object)a).Equals((object)b)); // true

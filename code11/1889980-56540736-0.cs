		string lower = "مرحبا بالعالم".ToLower();
		string upper= "مرحبا بالعالم".ToUpper();				
				
		Console.WriteLine(lower);
		Console.WriteLine(upper);
		//Equals even if we force it to be upper/lower case.
		Console.WriteLine(lower.Equals(upper));
		//Returns false
		Console.WriteLine("a".Equals("A"));
        //Returns: false.
		Console.WriteLine("a".Equals("A"));

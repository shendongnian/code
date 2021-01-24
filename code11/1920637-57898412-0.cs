        string reply = "";
		string userword = "";
		string splitword = "";
		int length = 0;
		int startingindex = 0; 
		System.Console.WriteLine("Enter a single world: ");
		userword = System.Console.ReadLine();
		System.Console.WriteLine("Enter a starting index: ");
		startingindex = Convert.ToInt32( System.Console.ReadLine());  
		
		System.Console.WriteLine("Enter a length: ");
		length = Convert.ToInt32(System.Console.ReadLine()); 
		
		splitword = userword.Substring(startingindex, length);
		System.Console.WriteLine(splitword);

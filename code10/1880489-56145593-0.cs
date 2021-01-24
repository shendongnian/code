    Console.WriteLine("Enter a string:");
	string s = Console.ReadLine();
	Console.WriteLine("Enter a character to remove:");
	string rs = Console.ReadLine().ToString();
    //Assuming if they enter 'a' you want to remove both 'a' AND 'A':
	string rsUpCase = rs.ToUpper();
	string rsLoCase = rs.ToLower();
	s = s.Replace(rsUpCase,"");		
	s = s.Replace(rsLoCase,"");
	Console.WriteLine(s);
	//Input:
	//Aardvarks are boring creatures
	//Result:
	//rdvrks re boring cretures

    List<int> lista = new List<int>() { 3, 4, 9, 8, 5, 6, 0, 3, 8, 3 };
		
    int number = lista.Count(n => n <= 5);  // will be 6 and elements are {3,4,5,0,3,3}
		
	var list  =  lista.Where(n => n <= 5).ToList(); // to check what elements in list after applying <= 5
		foreach(int n in list)
		{
			Console.Write(n+",");
			//output is 3,4,5,0,3,3,
		}

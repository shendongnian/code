    	List<int[,]> myList = new List<int[,]>();
	
		myList.Add(new int[,] {{1, 2}});
		myList.Add(new int[,] {{3, 4}});
		myList.Add(new int[,] {{5, 6}});
		Console.WriteLine(myList[0][0, 0]); // Output: 1
		Console.WriteLine(myList[2][0, 1]); // Output: 6

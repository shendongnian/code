    for(int i=0; i<arr.Length; i++){
    	Console.WriteLine($"Nr {i}:");
    	for(int j=0;j<arr[i].GetLength(0);j++){
    		for(int k=0;k<arr[i].GetLength(1);k++){
    			Console.Write($"{arr[i][j,k]} ");
    		}
    		Console.WriteLine();
    	}
    	Console.WriteLine();
    }

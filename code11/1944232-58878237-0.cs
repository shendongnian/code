    //I use a array to simulate the input PDF
    int[] input = new int[]{ 1, 2 };
    //And a list to simulate the output PDF
    List<int> output = new List<int>();
    
    //PageCopies is set somewhere outside this code.
    //The loop counting the copies
    for(int i = 0; i < PageCopies; i++){
      //the loop doing the copies
      for(int k = 0; k < input.Count; k++){
        output.Add(input[k]);
      }
    }
